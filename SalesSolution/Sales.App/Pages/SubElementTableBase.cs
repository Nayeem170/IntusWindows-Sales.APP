using MatBlazor;
using Microsoft.AspNetCore.Components;
using Sales.APP.Services.Contract;
using Sales.DTO.Models;

namespace Sales.APP.Pages
{
    public class SubElementTableBase : ComponentBase
    {
        [Inject]
        public ISubElementService SubElementService { get; set; }
        [Parameter]
        public IEnumerable<SubElementDTO> SubElements { get; set; }

        protected IEnumerable<SubElementDTO> DisplayedSubElements { get; set; }
        public IEnumerable<SubElementDTO> OldSubElements { get; set; }


        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            OldSubElements = SubElements;
            DisplayedSubElements = SubElements;
            SubElementSearchText = string.Empty;
        }

        private bool shouldUpdate()
        {
            if (OldSubElements.Count() != SubElements.Count())
            {
                return true;
            }

            var bothEquals = OldSubElements.OrderBy(old => old.UId)
                    .ThenBy(old => old.UpdatedAt)
                .SequenceEqual(SubElements.OrderBy(current => current.UId)
                    .ThenBy(current => current.UpdatedAt));

            return !bothEquals;
        }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();

            if (shouldUpdate())
            {
                OldSubElements = SubElements;
                DisplayedSubElements = SubElements;
                SubElementSearchText = string.Empty;
            }
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
                DisplayedSubElements = SubElements;
            }
            else
            {
                DisplayedSubElements = SubElements.Where(subElement =>
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
                    DisplayedSubElements = SubElements.OrderBy(order => order.Element);
                }
                else if (sort.SortId == "element" && sort.Direction == MatSortDirection.Desc)
                {
                    DisplayedSubElements = SubElements.OrderByDescending(order => order.Element);
                }
                else if (sort.SortId == "width" && sort.Direction == MatSortDirection.Asc)
                {
                    DisplayedSubElements = SubElements.OrderBy(order => order.Width);
                }
                else if (sort.SortId == "width" && sort.Direction == MatSortDirection.Desc)
                {
                    DisplayedSubElements = SubElements.OrderByDescending(order => order.Width);
                }
                else if (sort.SortId == "height" && sort.Direction == MatSortDirection.Asc)
                {
                    DisplayedSubElements = SubElements.OrderBy(order => order.Height);
                }
                else if (sort.SortId == "height" && sort.Direction == MatSortDirection.Desc)
                {
                    DisplayedSubElements = SubElements.OrderByDescending(order => order.Height);
                }
                else if (sort.SortId == "quantity" && sort.Direction == MatSortDirection.Asc)
                {
                    DisplayedSubElements = SubElements.OrderBy(order => order.Quantity);
                }
                else if (sort.SortId == "quantity" && sort.Direction == MatSortDirection.Desc)
                {
                    DisplayedSubElements = SubElements.OrderByDescending(order => order.Quantity);
                }
                else if (sort.SortId == "element-type" && sort.Direction == MatSortDirection.Asc)
                {
                    DisplayedSubElements = SubElements.OrderBy(order => order.ElementTypeName);
                }
                else if (sort.SortId == "element-type" && sort.Direction == MatSortDirection.Desc)
                {
                    DisplayedSubElements = SubElements.OrderByDescending(order => order.ElementTypeName);
                }
            }
        }
    }
}
