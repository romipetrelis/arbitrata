<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KoWithServerSideViewModel.aspx.cs" Inherits="KnockoutWebForms.KoWithServerSideViewModel" %>
<%@ Import Namespace="KnockoutWebForms" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Knockout with Server-side view-model</title>
    <script type="text/javascript" src="Scripts/jquery-2.1.3.min.js"></script>
    <script type="text/javascript" src="Scripts/knockout-3.3.0.js"></script>
    <script type="text/javascript" src="Scripts/knockout.mapping-latest.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div><input type="radio" value="new" name="addressType" data-bind="checked: SelectedAddressType" />New Address</div>
        <div data-bind="with: NewAddress, visible: $root.SelectedAddressType() == 'new'">
            <label for="newAddressLine1">Street</label>
            <input id="newAddressLine1" type="text" data-bind="value: Line1" />
            <label for="newAddressLine2">Apt, Suite, etc</label>
            <input id="newAddressLine2" type="text" data-bind="value:Line2" />
            <label for="newAddressCity">City</label>
            <input id="newAddressCity" type="text" data-bind="value: City"/>
            <label for="newAddressState">State/Province</label>
            <select id="newAddressState" data-bind="options: $root.AvailableStates, optionsText: 'DisplayText', optionsCaption: 'Choose a state', value: $root.SelectedStateProvince"></select>
            <label for="newAddressPostalCode">Zip</label>
            <input id="newAddressPostalCode" type="text" data-bind="value: PostalCode" />
        </div>

        <div><input type="radio" value="existing" name="addressType" data-bind="checked:SelectedAddressType"/>Existing Address </div>
        <div data-bind="visible: SelectedAddressType() == 'existing'">
            <select data-bind="options: AvailableAddresses, optionsText: 'DisplayText', optionsCaption: 'Choose an address', value: SelectedAddress"></select>
        </div>
    </div>
        <script>
            var AddressModel = function(data) {
                ko.mapping.fromJS(data, {}, this);

                this.DisplayText = ko.computed(function() {
                    return this.Line1() + " " + this.City() + ", " + this.State() + " " + this.PostalCode();
                }, this);
            },
            StateProvinceModel = function(data) {
                ko.mapping.fromJS(data, {}, this);

                this.DisplayText = ko.computed(function() {
                    return this.Abbreviation() + " - " + this.FullName();
                }, this);
            };

            $(function () {
                var mapping = {
                    'AvailableStates': {
                        create: function(options) {
                            return new StateProvinceModel(options.data);
                        }
                    },
                    'AvailableAddresses': {
                        create: function(options) {
                            return new AddressModel(options.data);
                        }
                    }
                };
                var vm = ko.mapping.fromJS(<%=Model.ToJson()%>, mapping);
                ko.applyBindings(vm);
            });
        </script>
    </form>
</body>
</html>
