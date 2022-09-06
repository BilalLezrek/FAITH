using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using Faith.Client;
using Faith.Client.Shared;
using MudBlazor;
using Shared.Posts;

namespace Faith.Client.Posts
{
    public partial class Tijdlijn : ComponentBase
    {
        bool success;
        string[] errors = {};
        MudTextField<string> pwField1;
        MudForm form;
        private bool isVisible;
        private bool _hidePosition;
        private bool _loading;
        private IEnumerable<PostDto.Index> posts;
        [Inject] public IPostService PostService { get; set; }
        void react()
        {
        }

        public void ToggleOverlay(bool value)
        {
            isVisible = value;
        }


        protected override async Task OnInitializedAsync()
        {
            await GetPostsAsync();
        }

        private async Task GetPostsAsync()
        {
            Console.WriteLine("ping van Client");
            var response = await PostService.GetIndexAsync(0);
            Console.WriteLine(posts);
            posts = response.Posts;
            Console.WriteLine(posts);
        }
    }

}