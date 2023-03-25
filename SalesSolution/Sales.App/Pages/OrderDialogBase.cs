using Microsoft.AspNetCore.Components;
using Sales.APP.Models;
using Sales.DTO.Models;

namespace Sales.APP.Pages
{
    public class OrderDialogBase : ComponentBase
    {
        [Parameter]
        public DialogueModel<OrderDTO> OrderDialogueModel { get; set; }
        [Parameter]
        public EventCallback OnSave { get; set; }
        [Parameter]
        public EventCallback OnCancel { get; set; }
    }
}
