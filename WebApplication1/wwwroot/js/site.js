// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var btn = document.getElementsByClassName("btn-delete");
for (var i = 0; i < btn.length; i++) {
    btn[i].onclick = function () {
        if (confirm("Are you sure ?")) {
            var currentBtn = this;
            var deleteId = this.id;
            alert(deleteId);
            var xhttp = new XMLHttpRequest();
            xhttp.onreadystatechange = function () {
                if (this.readyState === 4 && this.status === 200) {
                    alert("Delete Success!");
                    currentBtn.parentElement.remove();
                    location.reload();
                }

            }
            xhttp.open("DELETE", "/IdentityRole/Delete/?id=" + deleteId, true);
            xhttp.send();
        }
    }
}
