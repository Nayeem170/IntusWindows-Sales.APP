using Microsoft.AspNetCore.Components;
using Sales.APP.Enums;
using Sales.DTO.Models;

namespace Sales.APP.Pages
{
    public class OrderDialogBase : ComponentBase
    {
        [Parameter]
        public bool DialogIsOpen { get; set; }
        [Parameter]
        public string ActionType { get; set; }
        [Parameter]
        public OrderDTO Order { get; set; }
        [Parameter]
        public EventCallback OnSave { get; set; }
        [Parameter]
        public EventCallback OnCancel { get; set; }
    }
}
