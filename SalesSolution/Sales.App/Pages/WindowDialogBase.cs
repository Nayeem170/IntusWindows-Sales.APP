using Microsoft.AspNetCore.Components;
using Sales.APP.Models;
using Sales.DTO.Models;

namespace Sales.APP.Pages
{
    public class WindowDialogBase : ComponentBase
    {
        [Parameter]
        public DialogueModel<WindowDTO> DialogueModel { get; set; }
        [Parameter]
        public EventCallback OnSave { get; set; }
        [Parameter]
        public EventCallback OnCancel { get; set; }
    }
}
