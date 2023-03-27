using MatBlazor;
using Microsoft.AspNetCore.Components;
using Sales.APP.Enums;
using Sales.APP.Extentions;
using Sales.APP.Models;
using Sales.APP.Services.Contract;
using Sales.DTO.Extentions;
using Sales.DTO.Models;

namespace Sales.APP.Pages
{
    public class OrderTableBase : ComponentBase
    {
        #region Injects dependencies
        [Inject]
        public IOrderService OrderService { get; set; }
        [Inject]
        protected IMatToaster Toaster { get; set; }
        [Inject]
        protected IMatDialogService MatDialogService { get; set; }
        #endregion

        #region Declear parameters
        [Parameter]
        public IEnumerable<OrderDTO> Orders { get; set; }
        [Parameter]
        public EventCallback<OrderDTO> OnOrderSelected { get; set; }
        [Parameter]
        public EventCallback<OrderDTO> OnChange { get; set; }
        #endregion

        public DialogueModel<OrderDTO> OrderDialogueModel { get; set; } = new DialogueModel<OrderDTO>(new OrderDTO());
        private IEnumerable<OrderDTO> oldOrders { get; set; }
        protected IEnumerable<OrderDTO> DisplayedOrders = new List<OrderDTO>();


        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            oldOrders = Orders;
            DisplayedOrders = Orders;
            OrderSearchText = string.Empty;
        }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();

            if (!oldOrders.IsEquals(Orders))
            {
                oldOrders = Orders;
                DisplayedOrders = Orders;
                OrderSearchText = string.Empty;
                SortData(previousSortChangedEvent);
            }
        }

        protected void OnRowDbClick(object item)
        {
            var currentSelectedOrder = item as OrderDTO;
            OnOrderSelected.InvokeAsync(currentSelectedOrder);
        }

        private string _orderSearchText;
        protected string OrderSearchText
        {
            get => _orderSearchText;
            set
            {
                _orderSearchText = value;

                OrderSearchTextOnUpdate(value);
            }
        }

        private void OrderSearchTextOnUpdate(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                DisplayedOrders = Orders;
            }
            else
            {
                DisplayedOrders = Orders.Where(order =>
                    order.Name.Contains(text, StringComparison.OrdinalIgnoreCase) ||
                    order.State.Contains(text, StringComparison.OrdinalIgnoreCase));
            }
        }

        private MatSortChangedEvent previousSortChangedEvent = new MatSortChangedEvent();

        protected void SortData(MatSortChangedEvent sort)
        {
            previousSortChangedEvent = sort;

            if (!(sort == null || sort.Direction == MatSortDirection.None || string.IsNullOrEmpty(sort.SortId)))
            {

                if (sort.SortId == "name" && sort.Direction == MatSortDirection.Asc)
                {
                    DisplayedOrders = Orders.OrderBy(order => order.Name);
                }
                else if (sort.SortId == "name" && sort.Direction == MatSortDirection.Desc)
                {
                    DisplayedOrders = Orders.OrderByDescending(order => order.Name);
                }
                else if (sort.SortId == "state" && sort.Direction == MatSortDirection.Asc)
                {
                    DisplayedOrders = Orders.OrderBy(order => order.State);
                }
                else if (sort.SortId == "state" && sort.Direction == MatSortDirection.Desc)
                {
                    DisplayedOrders = Orders.OrderByDescending(order => order.State);
                }
            }
        }

        public void OpenAddOrderDialogue()
        {
            OrderDialogueModel
                .Clear()
                .AddDialogue()
                .Open();
        }

        public void OpenEditOrderDialogue(OrderDTO order)
        {
            OrderDialogueModel
                .Set(order)
                .EditDialogue()
                .Open();
        }

        public async Task OpenDeleteOrderPopupAsync(OrderDTO order)
        {
            var deleteThis = await MatDialogService.ConfirmAsync("Delete this order?");
            if (deleteThis)
            {
                var isDeleted = await OrderService.DeleteOrder(order);

                await OnChange.InvokeAsync();

                Action<string> toastAction = isDeleted ? Toaster.DeleteSuccessful
                                                        : Toaster.DeleteFailed;
                toastAction(DataModelType.Order);
            }
        }

        public void DeleteAOrder()
        {
            Console.WriteLine("Delete a order");
        }

        public void CancelAOrder()
        {
            Console.WriteLine("Delete a order");
        }

        protected async Task OnSaveAsync()
        {
            if (!OrderDialogueModel.IsOpen)
            {
                return;
            }

            var isSuccess = OrderDialogueModel.IsAdd()
                          ? await OrderService.AddOrder(OrderDialogueModel.ModelDTO)
                          : await OrderService.EditOrder(OrderDialogueModel.ModelDTO);

            if (isSuccess)
            {
                await OnChange.InvokeAsync();
                OrderDialogueModel.Close();
            }

            Action<string> toastAction = isSuccess
                ? (OrderDialogueModel.IsAdd() ? Toaster.CreateSuccessful : Toaster.UpdateSuccessful)
                : (OrderDialogueModel.IsAdd() ? Toaster.CreateFailed : Toaster.UpdateFailed);

            toastAction(DataModelType.Order);

            await OnOrderSelected.InvokeAsync(OrderDialogueModel.ModelDTO);
        }

        protected void OnCancel()
        {
            OrderDialogueModel.Close();
        }
    }
}
