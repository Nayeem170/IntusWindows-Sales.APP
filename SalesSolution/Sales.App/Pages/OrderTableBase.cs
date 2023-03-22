using MatBlazor;
using Microsoft.AspNetCore.Components;
using Sales.APP.Enums;
using Sales.DTO.Models;
using System;
using System.ComponentModel;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Sales.APP.Pages
{
    public class OrderTableBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<OrderDTO> Orders { get; set; }
        [Parameter]
        public EventCallback<OrderDTO> OnOrderSelected { get; set; }

        public OrderDTO Order { get; set; } = new OrderDTO();
        public string ActionType { get; set; } = FormActionType.Add;
        public bool DialogIsOpen { get; set; } = false;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            DisplayedOrders = Orders;
            SortData(null);
            await OnOrderSelected.InvokeAsync(DisplayedOrders.First());
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

        private OrderDTO _currentSelectedOrder = null;
        protected void OnRowDbClick(object item)
        {
            _currentSelectedOrder = item as OrderDTO;
            OnOrderSelected.InvokeAsync(_currentSelectedOrder);
        }

        public void OpenAddOrderDialogue()
        {
            Order = new OrderDTO();
            ActionType = FormActionType.Add;
            DialogIsOpen = true;
        }

        public void EditAOrder()
        {
            Console.WriteLine("Update a order");
        }

        public void DeleteAOrder()
        {
            Console.WriteLine("Delete a order");
        }

        public void SaveAOrder()
        {
            Console.WriteLine("Update a order");
        }

        public void CancelAOrder()
        {
            Console.WriteLine("Delete a order");
        }

        protected void OnSave()
        {
            DialogIsOpen = false;
        }

        protected void OnCancel()
        {
            DialogIsOpen = false;
        }
    }
}
