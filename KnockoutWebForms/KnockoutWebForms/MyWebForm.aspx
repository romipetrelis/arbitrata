<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyWebForm.aspx.cs" Inherits="KnockoutWebForms.MyWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="Scripts/jquery-2.1.3.min.js"></script>
    <script type="text/javascript" src="Scripts/knockout-3.3.0.js"></script>
    <script type="text/javascript">

        function ObservableSuperhero(data) {
            this.Name = ko.observable(data.Name);
            this.AlterEgo = ko.observable(data.AlterEgo);
            this.IsCaped = ko.observable(data.IsCaped);
        }

        function JsViewModel() {
            var self = this;

            self.superheroes = ko.observableArray([]);
            self.caped = ko.observable(false);
            self.caped.subscribe(function(newValue) {
                self.loadSuperheroes();
            });

            self.loadSuperheroes = function() {
                $.ajax({
                    url: '<%=ResolveUrl("MyWebForm.aspx/GetSuperheroesWrapper")%>',
                    type: "post",
                    contentType: "application/json; charset=utf-8",
                    data: ko.toJSON({ "caped": self.caped() }),
                    dataType: "json",
                    success: function (data) {
                        var results = $.map(data.d, function (item) {
                            return new ObservableSuperhero(item);
                        });
                        self.superheroes(results);
                    },
                    error: function (data, success, error) {
                        alert(error);
                    },
                    async: true
                });
            };
        }

        $(document).ready(function() {
            var vm = new JsViewModel();
            vm.loadSuperheroes();

            ko.applyBindings(vm);
        });
    </script>
    <title>Knockout with WebForms and WebMethods</title>
</head>
<body>
    <input type="checkbox" data-bind="checked: caped"/>
    <ul data-bind="foreach: superheroes">
        <li><span data-bind="text: Name"></span> (<span data-bind="text: AlterEgo"></span>)</li>
    </ul>
</body>
</html>
