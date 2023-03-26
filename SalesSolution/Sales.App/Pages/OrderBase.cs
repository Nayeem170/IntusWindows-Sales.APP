using MatBlazor;
using Microsoft.AspNetCore.Components;
using Sales.APP.Enums;
using Sales.APP.Extentions;
using Sales.APP.Services.Contract;
using Sales.DTO.Models;

namespace Sales.APP.Pages
{
    public class OrderBase : ComponentBase
    {
        [Inject]
        public IOrderService OrderService { get; set; }
        [Inject]
        public IWindowService WindowService { get; set; }
        [Inject]
        public ISubElementService SubElementService { get; set; }
        [Inject]
        public IElementTypeService ElementTypeService { get; set; }
        [Inject]
        protected IMatToaster Toaster { get; set; }

        public IEnumerable<OrderDTO> Orders { get; set; } = null;
        public IEnumerable<WindowDTO> Windows { get; set; } = null;
        public IEnumerable<SubElementDTO> SubElements { get; set; } = null;
        public IEnumerable<ElementTypeDTO> ElementTypes { get; set; } = null;

        public OrderDTO CurrentOrder { get; set; } = new OrderDTO();
        public WindowDTO CurrentWindow { get; set; } = new WindowDTO();

        protected override async Task OnInitializedAsync()
        {
            await LoadForOrderGrid();

            ElementTypes = await ElementTypeService.GetElementTypes();
        }

        protected async Task OnOrderChangeAsync()
        {
            await LoadForOrderGrid();
        }

        private async Task LoadForOrderGrid()
        {
            await LoadOrdersAsync();
            await LoadWindowsAsync(Orders.FirstOrDefault());
            await LoadSubElementsAsync(Windows.FirstOrDefault());
        }

        protected async Task ShowWindowsAsync(OrderDTO order)
        {
            CurrentOrder = order;
            await LoadForWindowGrid();
        }

        protected async Task OnWindowChangeAsync()
        {
            await LoadForWindowGrid();
        }

        private async Task LoadForWindowGrid()
        {
            await LoadWindowsAsync(CurrentOrder);
            await LoadSubElementsAsync(Windows.FirstOrDefault());
        }

        protected async Task ShowSubElementsAsync(WindowDTO window)
        {
            CurrentWindow = window;
            await LoadSubElementsAsync(window);
        }

        protected async Task OnSubElementChangeAsync()
        {
            await LoadForSubElementGrid();
            await LoadWindowsAsync(CurrentOrder);
        }

        private async Task LoadForSubElementGrid()
        {
            await LoadSubElementsAsync(CurrentWindow);
        }

        private async Task LoadOrdersAsync()
        {
            Orders = await OrderService.GetOrders();
            TestHasItems(Orders);
        }
        private async Task LoadWindowsAsync(OrderDTO order)
        {
            CurrentOrder = order;
            Windows = order?.UId == null ? new List<WindowDTO>()
                    : await WindowService.GetWindows(order.UId);
            TestHasItems(Windows);
        }
        private async Task LoadSubElementsAsync(WindowDTO window)
        {
            CurrentWindow = window;

            SubElements = window?.UId == null ? new List<SubElementDTO>()
                    : await SubElementService.GetSubElements(window.UId);
            TestHasItems(SubElements);
        }

        public void TestHasItems<T>(IEnumerable<T> items)
        {
            if (items.Any())
            {
                return;
            }

            var dataModelTypeMap = new Dictionary<Type, string>
            {
                { typeof(OrderDTO), DataModelType.Order },
                { typeof(WindowDTO), DataModelType.Window },
                { typeof(SubElementDTO), DataModelType.SubElement }
            };

            var dataType = typeof(T);
            if (dataModelTypeMap.TryGetValue(dataType, out var dataModelType))
            {
                Toaster.DataNotFound(dataModelType);
            }
        }
    }
}
