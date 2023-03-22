using Microsoft.AspNetCore.Components;
using Sales.APP.Services.Contract;
using Sales.DTO.Models;

namespace Sales.APP.Pages
{
    public class OrderBase : ComponentBase
    {
        [Inject]
        public IOrderService OrderService { get; set; }
        
        public IEnumerable<OrderDTO> Orders { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Orders = await OrderService.GetOrders();
        }

        protected OrderDTO CurrentSelectedOrder = null;
        protected void ShowWindows(OrderDTO order)
        {
            CurrentSelectedOrder = order;
            CurrentSelectedWindow = order.Windows.First();
        }

        protected WindowDTO CurrentSelectedWindow = null;
        protected void ShowSubElements(WindowDTO window)
        {
            CurrentSelectedWindow = window;
        }
    }
}
