(function () {
    'use strict';

    angular.module('app').controller('CustomerController', CustomerController);

    function CustomerController($http) {

        var vm = this;
        var dataService = $http;

        // Hook up public events
        vm.resetSearch = resetSearch;
        vm.searchImmediate = searchImmediate;
        vm.search = search;
        vm.addClick = addClick;
        vm.cancelClick = cancelClick;
        vm.editClick = editClick;
        vm.deleteClick = deleteClick;
        vm.saveClick = saveClick;

        vm.customer = {};
        vm.customers = [];
        vm.searchInput = {
            customerName: ''
        };

        const pageMode = {
            LIST: 'List',
            EDIT: 'Edit',
            ADD: 'Add'
        };

        vm.uiState = {
            mode: pageMode.LIST,
            isDetailAreaVisible: false,
            isListAreaVisible: true,
            isSearchAreaVisible: true,
            isValid: true,
            messages: []
        };

        customerList();


        function addClick() {
            vm.customer = initEntity();

            setUIState(pageMode.ADD);
        }


        function cancelClick(customerForm) {
            customerForm.$setPristine();
            customerForm.$valid = true;
            vm.uiState.isValid = true;

            setUIState(pageMode.LIST);
        }


        function editClick(id) {
            customerGet(id)
            setUIState(pageMode.EDIT);
        }


        function deleteClick(id) {
            if (confirm("Delete this Customer?")) {
                deleteData(id);
            }
        }


        function saveClick(customerForm) {
            //if (customerForm.$valid) {
            //    if (validateData()) {
            //        customerForm.$setPristine();
            if (vm.uiState.mode === pageMode.ADD) {
                insertData();
            }
            else {
                updateData();
            }
            //    }
            //    else {
            //        customerForm.$valid = false;
            //    }
            //}
            //else {
            //    vm.uiState.isValid = false;
            //}
        }


        function insertData() {
            dataService.post(
                "/api/Customer",
                vm.customer)
              .then(function (result) {
                  // Update product object
                  vm.customer = result.data;

                  // Add Product to Array
                  vm.customers.push(vm.customer);

                  setUIState(pageMode.LIST);
              }, function (error) {
                  handleException(error);
              });
        }


        function deleteData(id) {
            dataService.delete(
                      "/api/Customer/" + id)
              .then(function (result) {
                  // Get index of this customer
                  var index = vm.customers.map(function (p)
                  { return p.CustomerId; }).indexOf(id);

                  // Remove customer from array
                  vm.customers.splice(index, 1);

                  setUIState(pageMode.LIST);
              }, function (error) {
                  handleException(error);
              });
        }

        function updateData() {
            dataService.put("/api/Customer/" +
                  vm.customer.CustomerId,
                  vm.customer)
              .then(function (result) {
                  // Update product object
                  vm.customer = result.data;

                  // Get index of this product
                  var index = vm.customers.map(function (p)
                  { return p.CustomerId; })
                      .indexOf(vm.customer.CustomerId);

                  // Update product in array
                  vm.customers[index] = vm.customer;

                  setUIState(pageMode.LIST);
              }, function (error) {
                  handleException(error);
              });
        }


        function addValidationMessage(prop, msg) {
            vm.uiState.messages.push({
                property: prop,
                message: msg
            });
        }


        function validateData() {

            vm.uiState.messages = [];



            //if (vm.customer.Name == "") {
            //    addValidationMessage('Name', 'Name Cannot be blank.');
            //}

            //vm.uiState.isValid = (vm.uiState.messages.length == 0);

            //return vm.uiState.isValid;
            return true;
        }


        function customerGet(id) {

            dataService.get("/api/Customer/" + id)
              .then(function (result) {

                  vm.customer = result.data;

              }, function (error) {
                  handleException(error);
              });
        }




        function setUIState(state) {
            vm.uiState.mode = state;

            vm.uiState.isDetailAreaVisible =
              (state == pageMode.ADD || state == pageMode.EDIT);
            vm.uiState.isListAreaVisible = (state == pageMode.LIST);
            vm.uiState.isSearchAreaVisible = (state == pageMode.LIST);
        }


        function resetSearch() {
            vm.searchInput = {

                customerName: ''
            };

            customerList();
        }


        function initEntity() {
            return {

                Name: '',
                Address: '',
                Address2: '',
                Address3: '',
                Country: 0,
                State: 0,
                City: '',
                ZipCode: '',
                IsSameAsMailingAddress: false,
                BillingAddress: '',
                BillingAddress2: '',
                BillingAddress3: '',
                BillingCountry: 0,
                BillingState: 0,
                BillingCity: '',
                BillingZipCode: '',
                PrimaryContact: '',
                Telephone: '',
                Extension: '',
                Fax: '',
                TollFree: '',
                Email: '',
                SecondaryContact: '',
                SecondaryMail: '',
                IsBroker: false,
                Status: 0,
                UserId: 1

            };
        }

        function search() {
            // Create object literal for search values
            var searchEntity = {
                CustomerName:
                  vm.searchInput.customerName
            };


            dataService.post("/api/Customer/Search",
                    searchEntity)
              .then(function (result) {
                  vm.customers = result.data;

                  setUIState(pageMode.LIST);
              }, function (error) {
                  handleException(error);
              });
        }


        function searchImmediate(item) {
            if (vm.searchInput.customerName.length == 0 ? true : (item.customerName.toLowerCase().indexOf(vm.searchInput.customerName.toLowerCase()) >= 0)) {
                return true;
            }

            return false;
        }


        function customerList() {
            dataService.get("/api/Customer")
            .then(function (result) {
                vm.customers = result.data;

                setUIState(pageMode.LIST);
            },
            function (error) {
                handleException(error);
            });
        }


        function handleException(error) {
            vm.uiState.isValid = false;
            var msg = {
                property: 'Error',
                message: ''
            };

            vm.uiState.messages = [];

            switch (error.status) {
                case 400:   // 'Bad Request'
                    // Model state errors
                    var errors = error.data.ModelState;
                    debugger;

                    // Loop through and get all 
                    // validation errors
                    for (var key in errors) {
                        for (var i = 0; i < errors[key].length;
                                i++) {
                            addValidationMessage(key,
                                        errors[key][i]);
                        }
                    }

                    break;

                case 404:  // 'Not Found'
                    msg.message = 'The customer you were ' +
                                  'requesting could not be found';
                    vm.uiState.messages.push(msg);

                    break;

                case 500:  // 'Internal Error'
                    msg.message =
                      error.data.ExceptionMessage;
                    vm.uiState.messages.push(msg);

                    break;

                default:
                    msg.message = 'Status: ' +
                                error.status +
                                ' - Error Message: ' +
                                error.statusText;
                    vm.uiState.messages.push(msg);

                    break;
            }
        }
    }
})();
