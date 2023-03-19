using MatBlazor;
using Microsoft.AspNetCore.Components;
using Sales.DTO.Models;

namespace Sales.APP.Pages
{
    public class SubElementTableBase : ComponentBase
    {
        [Parameter]
        public WindowDTO Window { get; set; }

        protected IEnumerable<SubElementDTO> DisplayedSubElements = null;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            DisplayedSubElements = Window.SubElements;
            SortData(null);
        }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();
            DisplayedSubElements = Window.SubElements;
            SubElementSearchText = string.Empty;
        }

        private string _subElementSearchText;
        protected string SubElementSearchText
        {
            get => _subElementSearchText;
            set
            {
                _subElementSearchText = value;

                SubElementSearchTextOnUpdate(value);
            }
        }

        private void SubElementSearchTextOnUpdate(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                DisplayedSubElements = Window.SubElements;
            }
            else
            {
                DisplayedSubElements = Window.SubElements.Where(subElement =>
                    subElement.Element.ToString().Contains(text, StringComparison.OrdinalIgnoreCase) ||
                    subElement.Width.ToString().Contains(text, StringComparison.OrdinalIgnoreCase) ||
                    subElement.Height.ToString().Contains(text, StringComparison.OrdinalIgnoreCase) ||
                    subElement.Quantity.ToString().Contains(text, StringComparison.OrdinalIgnoreCase) ||
                    subElement.ElementTypeName.Contains(text, StringComparison.OrdinalIgnoreCase));
            }
        }

        protected void SortData(MatSortChangedEvent sort)
        {
            if (!(sort == null || sort.Direction == MatSortDirection.None || string.IsNullOrEmpty(sort.SortId)))
            {

                if (sort.SortId == "element" && sort.Direction == MatSortDirection.Asc)
                {
                    DisplayedSubElements = Window.SubElements.OrderBy(order => order.Element);
                }
                else if (sort.SortId == "element" && sort.Direction == MatSortDirection.Desc)
                {
                    DisplayedSubElements = Window.SubElements.OrderByDescending(order => order.Element);
                }
                else if (sort.SortId == "width" && sort.Direction == MatSortDirection.Asc)
                {
                    DisplayedSubElements = Window.SubElements.OrderBy(order => order.Width);
                }
                else if (sort.SortId == "width" && sort.Direction == MatSortDirection.Desc)
                {
                    DisplayedSubElements = Window.SubElements.OrderByDescending(order => order.Width);
                }
                else if (sort.SortId == "height" && sort.Direction == MatSortDirection.Asc)
                {
                    DisplayedSubElements = Window.SubElements.OrderBy(order => order.Height);
                }
                else if (sort.SortId == "height" && sort.Direction == MatSortDirection.Desc)
                {
                    DisplayedSubElements = Window.SubElements.OrderByDescending(order => order.Height);
                }
                else if (sort.SortId == "quantity" && sort.Direction == MatSortDirection.Asc)
                {
                    DisplayedSubElements = Window.SubElements.OrderBy(order => order.Quantity);
                }
                else if (sort.SortId == "quantity" && sort.Direction == MatSortDirection.Desc)
                {
                    DisplayedSubElements = Window.SubElements.OrderByDescending(order => order.Quantity);
                }
                else if (sort.SortId == "element-type" && sort.Direction == MatSortDirection.Asc)
                {
                    DisplayedSubElements = Window.SubElements.OrderBy(order => order.ElementTypeName);
                }
                else if (sort.SortId == "element-type" && sort.Direction == MatSortDirection.Desc)
                {
                    DisplayedSubElements = Window.SubElements.OrderByDescending(order => order.ElementTypeName);
                }
            }
        }
    }
}
