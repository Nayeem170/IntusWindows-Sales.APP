using MatBlazor;
using Microsoft.AspNetCore.Components;
using Sales.DTO.Models;

namespace Sales.APP.Pages
{
    public class WindowTableBase : ComponentBase
    {
        [Parameter]
        public OrderDTO Order { get; set; }
        [Parameter]
        public EventCallback<WindowDTO> OnWindowSelected { get; set; }

        protected IEnumerable<WindowDTO> DisplayedWindows = null;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            DisplayedWindows = Order.Windows;
            SortData(null);
            await OnWindowSelected.InvokeAsync(DisplayedWindows.First());
        }

        private bool shouldUpdate = true;
        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();

            if (shouldUpdate)
            {
                DisplayedWindows = Order.Windows;
                WindowSearchText = string.Empty;
            }
            else
            {
                shouldUpdate = true;
            }
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
                DisplayedWindows = Order.Windows;
            }
            else
            {
                DisplayedWindows = Order.Windows.Where(order =>
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
                    DisplayedWindows = Order.Windows.OrderBy(order => order.Name);
                }
                else if (sort.SortId == "name" && sort.Direction == MatSortDirection.Desc)
                {
                    DisplayedWindows = Order.Windows.OrderByDescending(order => order.Name);
                }
                else if (sort.SortId == "quantity-of-windows" && sort.Direction == MatSortDirection.Asc)
                {
                    DisplayedWindows = Order.Windows.OrderBy(order => order.Quantity);
                }
                else if (sort.SortId == "quantity-of-windows" && sort.Direction == MatSortDirection.Desc)
                {
                    DisplayedWindows = Order.Windows.OrderByDescending(order => order.Quantity);
                }
                else if (sort.SortId == "total-sub-elements" && sort.Direction == MatSortDirection.Asc)
                {
                    DisplayedWindows = Order.Windows.OrderBy(order => order.SubElements.Sum(element => element.Quantity));
                }
                else if (sort.SortId == "total-sub-elements" && sort.Direction == MatSortDirection.Desc)
                {
                    DisplayedWindows = Order.Windows.OrderByDescending(order => order.SubElements.Sum(element => element.Quantity));
                }
            }
        }

        private WindowDTO _currentSelectedWindow = null;
        protected void OnRowDbClick(object item)
        {
            _currentSelectedWindow = item as WindowDTO;
            OnWindowSelected.InvokeAsync(_currentSelectedWindow);
            shouldUpdate = false;
        }
    }
}
