using MatBlazor;
using Microsoft.AspNetCore.Components;
using Sales.APP.Enums;
using Sales.APP.Extentions;
using Sales.APP.Services.Contract;
using Sales.DTO.Models;
using Sales.LIB.Extentions;

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
        protected IMatToaster Toaster { get; set; }

        public IEnumerable<OrderDTO> Orders { get; set; } = new List<OrderDTO>();
        public IEnumerable<WindowDTO> Windows { get; set; } = new List<WindowDTO>();
        protected IEnumerable<SubElementDTO> SubElements { get; set; } = new List<SubElementDTO>();


        protected override async Task OnInitializedAsync()
        {
            await LoadOrdersAsync();
            await LoadWindowsAsync(Orders.FirstOrDefault()?.UId);
            await LoadSubElementsAsync(Windows.FirstOrDefault()?.UId);
        }

        protected async Task OnOrderChangeAsync()
        {
            await LoadOrdersAsync();
            await LoadWindowsAsync(Orders.FirstOrDefault()?.UId);
            await LoadSubElementsAsync(Windows.FirstOrDefault()?.UId);
        }

        protected async Task ShowWindowsAsync(OrderDTO order)
        {
            await LoadWindowsAsync(order.UId);
            await LoadSubElementsAsync(Windows.FirstOrDefault()?.UId);
        }

        protected async Task ShowSubElementsAsync(WindowDTO window)
        {
            await LoadSubElementsAsync(window.UId);
        }

        private async Task LoadOrdersAsync()
        {
            Orders = await OrderService.GetOrders();
            TestHasItems(Orders);
        }
        private async Task LoadWindowsAsync(Guid? orderId)
        {
            Windows = orderId.IsNull() ? new List<WindowDTO>()
                    : await WindowService.GetWindows(orderId.GetValueOrDefault());
            TestHasItems(Windows);
        }
        private async Task LoadSubElementsAsync(Guid? windowId)
        {
            SubElements = windowId.IsNull() ? new List<SubElementDTO>()
                    : await SubElementService.GetSubElements(windowId.GetValueOrDefault());
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
