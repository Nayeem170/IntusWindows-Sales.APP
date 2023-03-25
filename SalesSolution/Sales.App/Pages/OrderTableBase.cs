using MatBlazor;
using Microsoft.AspNetCore.Components;
using Sales.APP.Enums;
using Sales.APP.Extentions;
using Sales.APP.Models;
using Sales.APP.Services.Contract;
using Sales.DTO.Models;

namespace Sales.APP.Pages
{
    public class OrderTableBase : ComponentBase
    {
        [Inject]
        public IOrderService OrderService { get; set; }
        [Inject]
        protected IMatToaster Toaster { get; set; }
        [Inject]
        protected IMatDialogService MatDialogService { get; set; }
        [Parameter]
        public IEnumerable<OrderDTO> Orders { get; set; }
        [Parameter]
        public EventCallback<OrderDTO> OnOrderSelected { get; set; }
        [Parameter]
        public EventCallback<OrderDTO> OnChange { get; set; }

        public DialogueModel<OrderDTO> OrderDialogueModel { get; set; } = new DialogueModel<OrderDTO>(new OrderDTO());
        public IEnumerable<OrderDTO> OldOrders { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            OldOrders = Orders;
            DisplayedOrders = Orders;
            OrderSearchText = string.Empty;
        }

        private bool shouldUpdate()
        {
            if (OldOrders.Count() != Orders.Count())
            {
                return true;
            }

            var bothEquals = OldOrders.OrderBy(old => old.UId)
                    .ThenBy(old => old.UpdatedAt)
                .SequenceEqual(Orders.OrderBy(current => current.UId)
                    .ThenBy(current => current.UpdatedAt));

            return !bothEquals;
        }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();

            if (shouldUpdate())
            {
                OldOrders = Orders;
                DisplayedOrders = Orders;
                OrderSearchText = string.Empty;
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

        protected IEnumerable<OrderDTO> DisplayedOrders = null;
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

        protected void SortData(MatSortChangedEvent sort)
        {
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
            OrderDialogueModel.Close();

            var isSuccess = OrderDialogueModel.IsAdd()
                          ? await OrderService.AddOrder(OrderDialogueModel.ModelDTO)
                          : await OrderService.EditOrder(OrderDialogueModel.ModelDTO);

            await OnChange.InvokeAsync();

            Action<string> toastAction = isSuccess
                ? (OrderDialogueModel.IsAdd() ? Toaster.CreateSuccessful : Toaster.UpdateSuccessful)
                : (OrderDialogueModel.IsAdd() ? Toaster.CreateFailed : Toaster.UpdateFailed);

            toastAction(DataModelType.Order);
        }

        protected void OnCancel()
        {
            OrderDialogueModel.IsOpen = false;
        }
    }
}
