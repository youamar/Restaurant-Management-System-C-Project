using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssingnemntNote;
using Main_Page.Model;
using Main_Page.Order;
using Main_Page.Service;
using System.Windows.Forms;
using System.IO;

namespace Main_Page
{
    internal class MenuControl
    {

        private Form parentForm;

        private Button[] buttonsF;
        private Button[] buttonsC;
        private Label[] labelsD;

        private List<CategoryModel> categories;
        private List<MenuModel> foods;
        private List<MenuModel> descriptions;

        private Button _selectedButton;

        public MenuControl(Form parentForm, Button[] buttonsC, Button[] buttonsF, Label[] labelsD)
        {
            this.parentForm = parentForm;
            this.buttonsF = buttonsF;
            this.buttonsC = buttonsC;
            this.labelsD = labelsD;
        }

        public void LoadData()
        {
            CategoryService _categoryService = new CategoryService("VegeMeat");
            categories = _categoryService.GetAllCategory();
            BindCategoriesToButton();

            MenuService _menuService = new MenuService("VegeMeat");
            foods = _menuService.GetActiveMenu();
            descriptions = _menuService.GetActiveMenu();

            if (categories.Count > 0)
            {
                // 选中第一个类别
                CategoryModel defaultCategory = categories[0];


                // 根据默认类别过滤 foods
                List<MenuModel> filteredFoods = foods
                    .Where(f => f.category_id == defaultCategory.category_id)
                    .ToList();

                List<MenuModel> filteredDescriptions = descriptions
                    .Where(f => f.category_id == defaultCategory.category_id)
                    .ToList();

                // 绑定过滤后的食品到按钮
                BindFoodsToButton(filteredFoods);
                BindDescriptionToLabel(filteredDescriptions);

                buttonsC[0].PerformClick();
            }
        }

        private void BindCategoriesToButton()
        {
            for (int i = 0; i < buttonsC.Length && i < categories.Count; i++)
            {
                buttonsC[i].Text = categories[i].category_name;
                buttonsC[i].TextAlign = ContentAlignment.MiddleLeft;
                buttonsC[i].Tag = categories[i];
                buttonsC[i].Click += HandleCategoryButtonClick;
            }
        }

        private void BindFoodsToButton(List<MenuModel> filteredFoods)
        {
            for (int i = 0; i < buttonsF.Length; i++)
            {
                buttonsF[i].Text = "";

                if (i < filteredFoods.Count)
                {
                    buttonsF[i].Visible = true;

                    buttonsF[i].Tag = filteredFoods[i];

                    buttonsF[i].Click -= HandleFoodButtonClick;
                    buttonsF[i].Click += HandleFoodButtonClick;

                    if (filteredFoods[i].photo != null)
                    {
                        using (MemoryStream ms = new MemoryStream(filteredFoods[i].photo))
                        {
                            Image img = Image.FromStream(ms);

                            buttonsF[i].BackgroundImage = img;
                            buttonsF[i].BackgroundImageLayout = ImageLayout.Stretch; // 确保图片适应按钮大小
                        }
                    }
                    else
                    {
                        buttonsF[i].Text = filteredFoods[i].item_id.ToString();
                    }
                }
                else
                {
                    buttonsF[i].Visible = false;
                }
            }
        }

        private void BindDescriptionToLabel(List<MenuModel> filteredDescriptions)
        {
            for (int i = 0; i < labelsD.Length; i++)
            {
                if (i < filteredDescriptions.Count)
                {
                    labelsD[i].Text = $"{filteredDescriptions[i].item}\n{filteredDescriptions[i].price}";
                    labelsD[i].Visible = true;
                }
                else
                {
                    labelsD[i].Visible = false;
                }
            }
        }

        private string BindFoodsDetails(List<MenuModel> filteredFoods)
        {
            return string.Join("\n", filteredFoods.Select(f => $"{f.description} - {f.price}"));
        }

        private void HandleCategoryButtonClick(object sender, EventArgs e)
        {
            if (sender is Button button && button.Tag is CategoryModel selectedCategory)
            {
                if (_selectedButton != null)
                {
                    _selectedButton.BackColor = Color.LightCoral; // 默认颜色
                }

                button.BackColor = Color.Coral; // 选中颜色
                _selectedButton = button; // 记录当前按钮

                // 根据所选类别过滤 foods
                List<MenuModel> filteredFoods = foods
                    .Where(f => f.category_id == selectedCategory.category_id)
                    .ToList();

                List<MenuModel> filteredDescriptions = descriptions
                    .Where(f => f.category_id == selectedCategory.category_id)
                    .ToList();

                // 绑定食品按钮
                BindFoodsToButton(filteredFoods);
                BindDescriptionToLabel(filteredDescriptions);
                BindFoodsDetails(filteredFoods);
            }
        }

        private void HandleFoodButtonClick(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (button.Tag == null)
                {
                    return;
                }

                if (button.Tag is MenuModel selectedFood)
                {
                    if (parentForm is Menu menuForm)
                    {
                        Food obj1 = new Food(menuForm, selectedFood, CartControl.Instance);
                        obj1.Show();
                        menuForm.Hide();
                    }
                }
            }
        }
    }
}
