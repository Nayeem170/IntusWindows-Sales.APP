using MatBlazor;
using Microsoft.AspNetCore.Components;
using Sales.APP.Services.Contract;
using Sales.DTO.Models;

namespace Sales.APP.Pages
{
    public class WindowTableBase : ComponentBase
    {
        [Inject]
        public IWindowService WindowService { get; set; }
        [Parameter]
        public IEnumerable<WindowDTO> Windows { get; set; }
        [Parameter]
        public EventCallback<WindowDTO> OnWindowSelected { get; set; }

        protected IEnumerable<WindowDTO> DisplayedWindows = new List<WindowDTO>();
        public IEnumerable<WindowDTO> OldWindows { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            OldWindows = Windows;
            DisplayedWindows = Windows;
            WindowSearchText = string.Empty;
        }

        private bool shouldUpdate()
        {
            if (OldWindows.Count() != Windows.Count())
            {
                return true;
            }

            var bothEquals = OldWindows.OrderBy(old => old.UId)
                    .ThenBy(old => old.UpdatedAt)
                .SequenceEqual(Windows.OrderBy(current => current.UId)
                    .ThenBy(current => current.UpdatedAt));

            return !bothEquals;
        }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();

            if (shouldUpdate())
            {
                OldWindows = Windows;
                DisplayedWindows = Windows;
                WindowSearchText = string.Empty;
            }
        }

        protected async Task OnRowDbClickAsync(object item)
        {
            var currentSelectedWindow = item as WindowDTO;
            await OnWindowSelected.InvokeAsync(currentSelectedWindow);
        }

        private string _windowSearchText;
        protected string WindowSearchText
        {
            get => _windowSearchText;
            set
            {
                _windowSearchText = value;

                WindowSearchTextOnUpdate(value);
            }
        }

        private void WindowSearchTextOnUpdate(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                DisplayedWindows = Windows;
            }
            else
            {
                DisplayedWindows = Windows.Where(order =>
                    order.Name.Contains(text, StringComparison.OrdinalIgnoreCase) ||
                    order.Quantity.ToString().Contains(text, StringComparison.OrdinalIgnoreCase));
            }
        }

        protected void SortData(MatSortChangedEvent sort)
        {
            if (!(sort == null || sort.Direction == MatSortDirection.None || string.IsNullOrEmpty(sort.SortId)))
            {

                if (sort.SortId == "name" && sort.Direction == MatSortDirection.Asc)
                {
                    DisplayedWindows = Windows.OrderBy(order => order.Name);
                }
                else if (sort.SortId == "name" && sort.Direction == MatSortDirection.Desc)
                {
                    DisplayedWindows = Windows.OrderByDescending(order => order.Name);
                }
                else if (sort.SortId == "quantity-of-windows" && sort.Direction == MatSortDirection.Asc)
                {
                    DisplayedWindows = Windows.OrderBy(order => order.Quantity);
                }
                else if (sort.SortId == "quantity-of-windows" && sort.Direction == MatSortDirection.Desc)
                {
                    DisplayedWindows = Windows.OrderByDescending(order => order.Quantity);
                }
                else if (sort.SortId == "total-sub-elements" && sort.Direction == MatSortDirection.Asc)
                {
                    DisplayedWindows = Windows.OrderBy(order => order.SubElements.Sum(element => element.Quantity));
                }
                else if (sort.SortId == "total-sub-elements" && sort.Direction == MatSortDirection.Desc)
                {
                    DisplayedWindows = Windows.OrderByDescending(order => order.SubElements.Sum(element => element.Quantity));
                }
            }
        }
    }
}
