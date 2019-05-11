// create the module and name it CustomApp
var CustomApp = angular.module('CustomApp', ['ngRoute', 'angularUtils.directives.dirPagination', 'ngAnimate', 'ngFileUpload']);

function setSession(name, value) {

    localStorage.setItem(name, value);

}

function printContent(elmnt) {
    var restorepage = document.body.innerHTML;
    var printcontent = document.getElementById(elmnt).innerHTML;
    if (printcontent === "") {
    }
    else {
        document.body.innerHTML = printcontent;
        window.print();
    }
    document.body.innerHTML = restorepage;
    location.reload();
}

function convertNumberToWords(amount) {
    var words = new Array();
    words[0] = '';
    words[1] = 'One';
    words[2] = 'Two';
    words[3] = 'Three';
    words[4] = 'Four';
    words[5] = 'Five';
    words[6] = 'Six';
    words[7] = 'Seven';
    words[8] = 'Eight';
    words[9] = 'Nine';
    words[10] = 'Ten';
    words[11] = 'Eleven';
    words[12] = 'Twelve';
    words[13] = 'Thirteen';
    words[14] = 'Fourteen';
    words[15] = 'Fifteen';
    words[16] = 'Sixteen';
    words[17] = 'Seventeen';
    words[18] = 'Eighteen';
    words[19] = 'Nineteen';
    words[20] = 'Twenty';
    words[30] = 'Thirty';
    words[40] = 'Forty';
    words[50] = 'Fifty';
    words[60] = 'Sixty';
    words[70] = 'Seventy';
    words[80] = 'Eighty';
    words[90] = 'Ninety';
    amount = amount.toString();
    var atemp = amount.split(".");
    var number = atemp[0].split(",").join("");
    var n_length = number.length;
    var words_string = "";
    if (n_length <= 9) {
        var n_array = new Array(0, 0, 0, 0, 0, 0, 0, 0, 0);
        var received_n_array = new Array();
        for (var i = 0; i < n_length; i++) {
            received_n_array[i] = number.substr(i, 1);
        }
        for (var i = 9 - n_length, j = 0; i < 9; i++, j++) {
            n_array[i] = received_n_array[j];
        }
        for (var i = 0, j = 1; i < 9; i++, j++) {
            if (i == 0 || i == 2 || i == 4 || i == 7) {
                if (n_array[i] == 1) {
                    n_array[j] = 10 + parseInt(n_array[j]);
                    n_array[i] = 0;
                }
            }
        }
        value = "";
        for (var i = 0; i < 9; i++) {
            if (i == 0 || i == 2 || i == 4 || i == 7) {
                value = n_array[i] * 10;
            } else {
                value = n_array[i];
            }
            if (value != 0) {
                words_string += words[value] + " ";
            }
            if ((i == 1 && value != 0) || (i == 0 && value != 0 && n_array[i + 1] == 0)) {
                words_string += "Crores ";
            }
            if ((i == 3 && value != 0) || (i == 2 && value != 0 && n_array[i + 1] == 0)) {
                words_string += "Lakhs ";
            }
            if ((i == 5 && value != 0) || (i == 4 && value != 0 && n_array[i + 1] == 0)) {
                words_string += "Thousand ";
            }
            if (i == 6 && value != 0 && (n_array[i + 1] != 0 && n_array[i + 2] != 0)) {
                words_string += "Hundred and ";
            } else if (i == 6 && value != 0) {
                words_string += "Hundred ";
            }
        }
        words_string = words_string.split("  ").join(" ");
    }
    return words_string;
}

// configure our routes
CustomApp.config(function ($routeProvider) {
    $routeProvider

        // route for the home page
        .when('/', {
            templateUrl: 'DashBoard.html',
            controller: 'DashBoardController'
        })

        .when('/Users', {
            templateUrl: 'pages/Users.html',
            controller: 'UserController'
        })

        .when('/Suppliers', {
            templateUrl: 'pages/Suppliers.html',
            controller: 'SupplierController'
        })

        .when('/Customers', {
            templateUrl: 'pages/Customers.html',
            controller: 'CustomerController'
        })

        .when('/Employees', {
            templateUrl: 'pages/Employees.html',
            controller: 'EmployeeController'
        })

        .when('/Expenses', {
            templateUrl: 'pages/Expenses.html',
            controller: 'ExpenseController'
        })

        .when('/Categories', {
            templateUrl: 'pages/Categories.html',
            controller: 'CategoriesController'
        })

        .when('/Warehouses', {
            templateUrl: 'pages/Warehouses.html',
            controller: 'WarehouseController'
        })

        .when('/Products', {
            templateUrl: 'pages/Products.html',
            controller: 'ProductController'
        })

        .when('/Reports', {
            templateUrl: 'pages/Reports.html',
            controller: 'ReportController'
        })

        .when('/Purchase', {
            templateUrl: 'pages/Purchase.html',
            controller: 'PurchaseController'
        })
    
        .when('/SalesContract', {
            templateUrl: 'pages/SalesContract.html',
            controller: 'SalesContractController'
        })

        .when('/Sales', {
            templateUrl: 'pages/Sales.html',
            controller: 'SalesController'
        });
});

// create the controller and inject Angular's $scope
CustomApp.controller('mainController', ['$scope', '$http', '$filter', '$window', function ($scope, $http, $filter, $window) {

    $scope.Login =
       {
           Email: "",
           Password: ""
       };

    var config = {
        headers: {
            'Accept': 'application/json', 'Content-Type': 'application/json; charset=utf-8'
        }
    }

    $scope.UserSesn =
        {
            UserIDNumber: "",
            UserID: "",
            UserName: "",
            UserType: "",
            IsSuperUser: "",
            CompanyID: "",
            CompanyName: "",
            IsAdmin: "",
            CompanyAddress: ""
        }

    debugger;
    //localStorage.clear();
    var arrUserSesn = localStorage.getItem('UserSession');
    $scope.UserSesn = arrUserSesn ? JSON.parse(arrUserSesn) : [];
    //var UserTime = localStorage.getItem('UserTime');

    $scope.Logout = function () {
        debugger;
        localStorage.clear();
        $scope.UserSesn = null;
        window.location.replace('Login.html');
    }

    $scope.DoLogin = function () {
        debugger;
        $http.post("/api/Account/UserLogin", $scope.Login, config).then(function (data, status, headers, config) {
            debugger;
            $scope.UserSession = data.data;
            if ($scope.UserSession.ResponseCode == 200) {
                //$('#alertLoginMessage').html($scope.User.ResponseMessage);
                //$('#alertLoginPopup').modal();
                $scope.UserSesn = $scope.UserSession;
                setSession('UserSession', JSON.stringify($scope.UserSesn));
                window.location.replace('index.html');
            }
            else {
                $('#alertLoginMessage').html($scope.UserSession.ResponseMessage);
                $('#alertLoginPopup').modal();
            }
        });
    }
}]);

CustomApp.controller('DashBoardController', ['$scope', '$http', '$filter', '$window', function ($scope, $http, $filter, $window) {

    var config = {
        headers: {
            'Accept': 'application/json', 'Content-Type': 'application/json; charset=utf-8'
        }
    }

    function GetDashBoardData() {
        $http.get("/api/DashBoard/GetDashBoardData").then(function (response) {
            debugger;
            $scope.DashBoardData = response.data;
        });
    }

    GetDashBoardData();

}]);

CustomApp.controller('UserController', ['$scope', '$http', '$filter', '$window', function ($scope, $http, $filter, $window) {
    $scope.message = 'Look! I am an about page.';

    $scope.Errormessage = '';

    $scope.AddUser = false;
    $scope.UserGrid = true;

    $scope.userPopupHeading = '';
    $scope.userPopupBtn = '';

    var config = {
        headers: {
            'Accept': 'application/json', 'Content-Type': 'application/json; charset=utf-8'
        }
    }

    $scope.SortUser = function (keyname) {
        $scope.sortKey = keyname;   //set the sortKey to the param passed
        $scope.reverse = !$scope.reverse; //if true make it false and vice versa
    }

    $scope.NewUser =
    {
        IDNUMBER: 0,
        CompanyID: 1,
        UserType: 0,
        UserID: "",
        UserName: "",
        pswd: "",
        EmailID: "",
        MobileNo: "",
        BOD: '',
        IsActive: 1,
        IsSuperUser: 0,
    }
    function GetUsers() {
        $http.get("/api/User/GetUsers").then(function (response) {
            debugger;
            $scope.Users = response.data;
            $scope.UseritemsPerPage = 10;
        });
    }

    GetUsers();

    $scope.SaveUser = function () {


        $scope.NewUser.BOD = $("#datepickerBOD").val();
        $scope.NewUser.MobileNo = $("#UserMobileNo").val();

        if ($scope.NewUser.UserID.length <= 2) {
            $scope.Errormessage = 'please enter valid User ID';
            return;
        }

        if ($scope.NewUser.UserName.length <= 2) {
            $scope.Errormessage = 'please enter valid User Name';
            return;
        }

        if ($scope.NewUser.UserType < 1 || $scope.NewUser.UserType > 2) {
            $scope.Errormessage = 'please Select valid User Type';
            return;
        }

        if ($scope.NewUser.BOD == "" || $scope.NewUser.BOD == null) {
            $scope.Errormessage = 'please Enter valid Birth date';
            return;
        }

        if ($scope.NewUser.MobileNo < 10) {
            $scope.Errormessage = 'please Select valid Mobile no';
            return;
        }

        if ($scope.NewUser.EmailID == undefined || $scope.NewUser.EmailID == "" || !validateEmail($scope.NewUser.EmailID)) {
            $scope.Errormessage = 'please enter valid Email';
            return;
        }

        if ($scope.NewUser.UserID.length <= 2) {
            $scope.Errormessage = 'max 3 characters require in Password';
            return;
        }

        debugger;
        $http.post("/api/User/CreateUser", $scope.NewUser, config).success(function (data, status, headers, config) {
            debugger;
            //$scope.Tempdata = data;

            if (data.ResponseCode == 200 && data.ResponseGenID != null && data.ResponseGenID != 0) {
                $('#alertMessage').html(data.ResponseMessage);
                $('#alertPopup').modal();

                setTimeout(function () {
                    $('#alertPopup').modal('hide');
                }, 1500);

                GetUsers();
                $scope.AddUser = !$scope.AddUser;
                $scope.UserGrid = !$scope.UserGrid;
            }
            else {
                $('#alertMessage').html(data.ResponseMessage);
                $('#alertPopup').modal();
            }

        });
    }

    $scope.EditUser = function (UID) {
        $scope.userPopupHeading = 'Update User';
        $scope.userPopupBtn = 'Update User';
        $scope.AddUser = !$scope.AddUser;
        $scope.UserGrid = !$scope.UserGrid;
        $scope.Errormessage = '';
        debugger;
        $scope.filteredTicket = $filter('filter')($scope.Users, { IDNUMBER: UID }, true);
        //$scope.NewUser = $scope.filteredTicket[0];
        $scope.NewUser.IDNUMBER = $scope.filteredTicket[0].IDNUMBER;
        $scope.NewUser.UserID = $scope.filteredTicket[0].UserID;
        $scope.NewUser.UserName = $scope.filteredTicket[0].UserName;
        $scope.NewUser.EmailID = $scope.filteredTicket[0].EmailID;
        $scope.NewUser.MobileNo = $scope.filteredTicket[0].MobileNo;
        $scope.NewUser.BOD = $scope.filteredTicket[0].BOD;
        $("#datepickerBOD").val($scope.NewUser.BOD);
        if ($scope.filteredTicket[0].UserTypeName == 'Administrator') {
            $scope.NewUser.UserType = 1
        }
        else { $scope.NewUser.UserType = 2 }
    }

    $scope.RemoveUserID = '';

    $scope.DeleteUser = function (userID) {
        $('#confirmMessage').html("Are you sure you want to delete?");
        $('#confirmUserPopup').modal();
        $scope.RemoveUserID = userID;
        return false;
    }

    $scope.RemoveUser = function () {
        debugger;
        $('#confirmUserPopup').modal('hide');
        $('#pleaseWaitDialog').modal();
        var UID = $scope.RemoveUserID;
        $http.get("/api/User/DeleteUser?UserID=" + UID).then(function (response) {
            debugger;
            if (response.data.ResponseCode == 200) {
                $('#pleaseWaitDialog').modal('hide');
                $('#alertMessage').html(response.data.ResponseMessage);
                $('#alertPopup').modal();

                setTimeout(function () {
                    $('#alertPopup').modal('hide');
                }, 1500);

                GetUsers();
            }
            else {
                $('#pleaseWaitDialog').modal('hide');
                $('#alertMessage').html(response.data.ResponseMessage);
                $('#alertPopup').modal();
            }

        });

    }

    $scope.CloseAddUser = function () {
        $scope.AddUser = !$scope.AddUser;
        $scope.UserGrid = !$scope.UserGrid;
    }

    $scope.ClearUser = function () {
        $scope.userPopupHeading = 'Add New User';
        $scope.userPopupBtn = 'Save User';
        $scope.AddUser = !$scope.AddUser;
        $scope.UserGrid = !$scope.UserGrid;
        $scope.Errormessage = '';

        $scope.NewUser =
        {
            IDNUMBER: 0,
            CompanyID: 1,
            UserType: 1,
            UserID: "",
            UserName: "",
            pswd: "",
            EmailID: "",
            MobileNo: "",
            BOD: '',
            IsActive: 1,
            IsSuperUser: 0,
        }
    }

}]);

CustomApp.controller('SupplierController', ['$scope', '$http', '$filter', '$window', function ($scope, $http, $filter, $window) {
    $scope.message = 'Contact us! JK. This is just a demo.';
    $scope.Errormessage = '';

    $scope.AddSupplier = false;
    $scope.SupplierGrid = true;

    $scope.SupplierPopupHeading = '';
    $scope.SupplierPopupBtn = '';

    var config = {
        headers: {
            'Accept': 'application/json', 'Content-Type': 'application/json; charset=utf-8'
        }
    }

    $scope.SortSupplier = function (keyname) {
        $scope.sortKey = keyname;   //set the sortKey to the param passed
        $scope.reverse = !$scope.reverse; //if true make it false and vice versa
    }

    $scope.NewSupplier =
    {
        IDNUMBER: 0,
        SupplierName: '',
        SupplierAddress: '',
        EmailID: '',
        PhoneNo1: '',
        PhoneNo2: '',
        CompanyName: '',
        CompAddress: '',
        CompEmail: '',
        Website: '',
        Designation: '',
        ShippingAddress: '',
        ContFirstName1: '',
        ContSurname1: '',
        ContPosition1: '',
        ContEmail1: '',
        ContPhone1: '',
        ContFirstName2: '',
        ContSurname2: '',
        ContPosition2: '',
        ContEmail2: '',
        ContPhone2: '',
        BankName: '',
        AccountNumber: '',
        IBAN: '',
        SWIFT: '',
        BankAddress: '',
        Note: '',
        CompanyID: 1,
        IsActive: 1,
    }
    function GetSuppliers() {
        $http.get("/api/Supplier/GetSuppliers").then(function (response) {
            debugger;
            $scope.Suppliers = response.data;
            $scope.SupplieritemsPerPage = 10;
        });
    }
    GetSuppliers();

    $scope.SaveSupplier = function () {

        debugger;
        if ($scope.NewSupplier.SupplierName == undefined || $scope.NewSupplier.SupplierName.length <= 2) {
            $scope.Errormessage = 'please enter valid Supplier Name';
            return;
        }

        if ($scope.NewSupplier.SupplierAddress == undefined || $scope.NewSupplier.SupplierAddress.length <= 2) {
            $scope.Errormessage = 'please enter valid Supplier Address';
            return;
        }

        if ($scope.NewSupplier.EmailID == undefined || $scope.NewSupplier.EmailID == "" || !validateEmail($scope.NewSupplier.EmailID)) {
            $scope.Errormessage = 'please enter valid Supplier Email';
            return;
        }

        if ($scope.NewSupplier.CompanyName == undefined || $scope.NewSupplier.CompanyName.length <= 2) {
            $scope.Errormessage = 'please enter valid Company Name';
            return;
        }

        if ($scope.NewSupplier.CompAddress == undefined || $scope.NewSupplier.CompAddress.length <= 2) {
            $scope.Errormessage = 'please enter valid Company Address';
            return;
        }

        if ($scope.NewSupplier.CompEmail == undefined || $scope.NewSupplier.CompEmail == "" || !validateEmail($scope.NewSupplier.CompEmail)) {
            $scope.Errormessage = 'please enter valid Company Email';
            return;
        }

        debugger;
        $http.post("/api/Supplier/CreateSupplier", $scope.NewSupplier, config).success(function (data, status, headers, config) {
            debugger;
            //$scope.Tempdata = data;

            if (data.ResponseCode == 200 && data.ResponseGenID != null && data.ResponseGenID != 0) {
                $('#alertMessage').html(data.ResponseMessage);
                $('#alertPopup').modal();

                setTimeout(function () {
                    $('#alertPopup').modal('hide');
                }, 1500);

                GetSuppliers();
                $scope.AddSupplier = !$scope.AddSupplier;
                $scope.SupplierGrid = !$scope.SupplierGrid;
            }
            else {
                $('#alertMessage').html(data.ResponseMessage);
                $('#alertPopup').modal();
            }

        });
    }

    $scope.EditSupplier = function (SupID) {
        $scope.SupplierPopupHeading = 'Update Supplier';
        $scope.SupplierPopupBtn = 'Update Supplier';
        $scope.AddSupplier = !$scope.AddSupplier;
        $scope.SupplierGrid = !$scope.SupplierGrid;
        $scope.Errormessage = '';
        debugger;
        $scope.filteredTicket = $filter('filter')($scope.Suppliers, { IDNUMBER: SupID }, true);
        $scope.NewSupplier = $scope.filteredTicket[0];
        $scope.NewSupplier.IDNUMBER = $scope.filteredTicket[0].IDNUMBER;

    }

    $scope.RemoveSupplierID = '';

    $scope.DeleteSupplier = function (supplierID) {
        $('#confirmMessage').html("Are you sure you want to delete?");
        $('#confirmSupplierPopup').modal();
        $scope.RemoveSupplierID = supplierID;
        return false;
    }

    $scope.RemoveSupplier = function () {
        debugger;
        $('#confirmSupplierPopup').modal('hide');
        $('#pleaseWaitDialog').modal();
        var SupID = $scope.RemoveSupplierID;
        $http.get("/api/Supplier/DeleteSupplier?SupplierID=" + SupID).then(function (response) {
            debugger;
            if (response.data.ResponseCode == 200) {
                $('#pleaseWaitDialog').modal('hide');
                $('#alertMessage').html(response.data.ResponseMessage);
                $('#alertPopup').modal();

                setTimeout(function () {
                    $('#alertPopup').modal('hide');
                }, 1500);

                GetSuppliers();
            }
            else {
                $('#pleaseWaitDialog').modal('hide');
                $('#alertMessage').html(response.data.ResponseMessage);
                $('#alertPopup').modal();
            }

        });
    }

    $scope.CloseAddSupplier = function () {
        $scope.AddSupplier = !$scope.AddSupplier;
        $scope.SupplierGrid = !$scope.SupplierGrid;
    }

    $scope.ClearSupplier = function () {
        $scope.SupplierPopupHeading = 'Add New Supplier';
        $scope.SupplierPopupBtn = 'Save Supplier';
        $scope.AddSupplier = !$scope.AddSupplier;
        $scope.SupplierGrid = !$scope.SupplierGrid;
        $scope.Errormessage = '';
        $scope.NewSupplier =
        {
            IDNUMBER: 0,
            SupplierName: '',
            SupplierAddress: '',
            EmailID: '',
            PhoneNo1: '',
            PhoneNo2: '',
            CompanyName: '',
            CompAddress: '',
            CompEmail: '',
            Website: '',
            Designation: '',
            ShippingAddress: '',
            ContFirstName1: '',
            ContSurname1: '',
            ContPosition1: '',
            ContEmail1: '',
            ContPhone1: '',
            ContFirstName2: '',
            ContSurname2: '',
            ContPosition2: '',
            ContEmail2: '',
            ContPhone2: '',
            BankName: '',
            AccountNumber: '',
            IBAN: '',
            SWIFT: '',
            BankAddress: '',
            Note: '',
            CompanyID: 1,
            IsActive: 1,
        }
    }

}]);

CustomApp.controller('CustomerController', ['$scope', '$http', '$filter', '$window', function ($scope, $http, $filter, $window) {
    $scope.message = 'Look! I am an about page.';
    $scope.Errormessage = '';

    $scope.CustomerPopupHeading = '';
    $scope.CustomerPopupBtn = '';

    $scope.AddCustomer = false;
    $scope.CustomerGrid = true;

    var config = {
        headers: {
            'Accept': 'application/json', 'Content-Type': 'application/json; charset=utf-8'
        }
    }

    $scope.SortCustomer = function (keyname) {
        $scope.sortKey = keyname;   //set the sortKey to the param passed
        $scope.reverse = !$scope.reverse; //if true make it false and vice versa
    }

    $scope.NewCustomer =
    {
        IDNUMBER: 0,
        CustomerName: '',
        CustomerAddress: '',
        EmailID: '',
        PhoneNo1: '',
        PhoneNo2: '',
        CompanyName: '',
        CompAddress: '',
        CompEmail: '',
        Website: '',
        Designation: '',
        ShippingAddress: '',
        ContFirstName1: '',
        ContSurname1: '',
        ContPosition1: '',
        ContEmail1: '',
        ContPhone1: '',
        ContFirstName2: '',
        ContSurname2: '',
        ContPosition2: '',
        ContEmail2: '',
        ContPhone2: '',
        Note: '',
        CompanyID: 1,
        IsActive: 1,
    }

    function GetCustomers() {
        $http.get("/api/Customer/GetCustomers").then(function (response) {
            debugger;
            $scope.Customers = response.data;
            $scope.CustomeritemsPerPage = 10;
        });
    }

    GetCustomers();

    $scope.SaveCustomer = function () {
        debugger;
        if ($scope.NewCustomer.CustomerName == undefined || $scope.NewCustomer.CustomerName.length <= 2) {
            $scope.Errormessage = 'please enter valid Customer Name';
            return;
        }

        if ($scope.NewCustomer.CustomerAddress == undefined || $scope.NewCustomer.CustomerAddress.length <= 2) {
            $scope.Errormessage = 'please enter valid Customer Address';
            return;
        }

        if ($scope.NewCustomer.EmailID == undefined || $scope.NewCustomer.EmailID == "" || !validateEmail($scope.NewCustomer.EmailID)) {
            $scope.Errormessage = 'please enter valid Customer Email';
            return;
        }

        if ($scope.NewCustomer.CompanyName == undefined || $scope.NewCustomer.CompanyName.length <= 2) {
            $scope.Errormessage = 'please enter valid Company Name';
            return;
        }

        if ($scope.NewCustomer.CompAddress == undefined || $scope.NewCustomer.CompAddress.length <= 2) {
            $scope.Errormessage = 'please enter valid Company Address';
            return;
        }

        if ($scope.NewCustomer.CompEmail == undefined || $scope.NewCustomer.CompEmail == "" || !validateEmail($scope.NewCustomer.CompEmail)) {
            $scope.Errormessage = 'please enter valid Company Email';
            return;
        }

        $http.post("/api/Customer/CreateCustomer", $scope.NewCustomer, config).success(function (data, status, headers, config) {
            debugger;
            if (data.ResponseCode == 200 && data.ResponseGenID != null && data.ResponseGenID != 0) {
                $('#alertMessage').html(data.ResponseMessage);
                $('#alertPopup').modal();

                setTimeout(function () {
                    $('#alertPopup').modal('hide');
                }, 1500);

                GetCustomers();
                $scope.AddCustomer = !$scope.AddCustomer;
                $scope.CustomerGrid = !$scope.CustomerGrid
            }
            else {
                $('#alertMessage').html(data.ResponseMessage);
                $('#alertPopup').modal();
            }

        });
    }

    $scope.EditCustomer = function (CustID) {
        $scope.CustomerPopupHeading = 'Update Customer';
        $scope.CustomerPopupBtn = 'Update Customer';
        $scope.AddCustomer = !$scope.AddCustomer;
        $scope.CustomerGrid = !$scope.CustomerGrid;
        $scope.Errormessage = '';
        debugger;
        $scope.filteredTicket = $filter('filter')($scope.Customers, { IDNUMBER: CustID }, true);
        $scope.NewCustomer = $scope.filteredTicket[0];
        $scope.NewCustomer.IDNUMBER = $scope.filteredTicket[0].IDNUMBER;
    }

    $scope.RemoveCustomerID = '';

    $scope.DeleteCustomer = function (customerID) {
        $('#confirmMessage').html("Are you sure you want to delete?");
        $('#confirmCustomerPopup').modal();
        $scope.RemoveCustomerID = customerID;
        return false;
    }

    $scope.RemoveCustomer = function () {
        debugger;
        $('#confirmCustomerPopup').modal('hide');
        $('#pleaseWaitDialog').modal();
        var CustID = $scope.RemoveCustomerID;
        $http.get("/api/Customer/DeleteCustomer?CustomerID=" + CustID).then(function (response) {
            debugger;
            if (response.data.ResponseCode == 200) {
                $('#pleaseWaitDialog').modal('hide');
                $('#alertMessage').html(response.data.ResponseMessage);
                $('#alertPopup').modal();

                setTimeout(function () {
                    $('#alertPopup').modal('hide');
                }, 1500);

                GetCustomers();
            }
            else {
                $('#pleaseWaitDialog').modal('hide');
                $('#alertMessage').html(response.data.ResponseMessage);
                $('#alertPopup').modal();
            }

        });

    }

    $scope.CloseAddCustomer = function () {
        $scope.AddCustomer = !$scope.AddCustomer;
        $scope.CustomerGrid = !$scope.CustomerGrid;
    }

    $scope.ClearCustomer = function () {
        $scope.CustomerPopupHeading = 'Add New Customer';
        $scope.CustomerPopupBtn = 'Save Customer';
        $scope.AddCustomer = !$scope.AddCustomer;
        $scope.CustomerGrid = !$scope.CustomerGrid;
        $scope.Errormessage = '';
        $scope.NewCustomer =
        {
            IDNUMBER: 0,
            CustomerName: '',
            CustomerAddress: '',
            EmailID: '',
            PhoneNo1: '',
            PhoneNo2: '',
            CompanyName: '',
            CompAddress: '',
            CompEmail: '',
            Website: '',
            Designation: '',
            ShippingAddress: '',
            ContFirstName1: '',
            ContSurname1: '',
            ContPosition1: '',
            ContEmail1: '',
            ContPhone1: '',
            ContFirstName2: '',
            ContSurname2: '',
            ContPosition2: '',
            ContEmail2: '',
            ContPhone2: '',
            Note: '',
            CompanyID: 1,
            IsActive: 1,
        }
    }

}]);

CustomApp.controller('EmployeeController', ['$scope', '$http', '$filter', '$window', function ($scope, $http, $filter, $window) {
    $scope.message = 'Look! I am an about page.';
    $scope.Errormessage = '';

    $scope.EmployeePopupHeading = '';
    $scope.EmployeePopupBtn = '';

    $scope.AddEmployee = false;
    $scope.EmployeeGrid = true;

    var config = {
        headers: {
            'Accept': 'application/json', 'Content-Type': 'application/json; charset=utf-8'
        }
    }

    $scope.SortEmployee = function (keyname) {
        $scope.sortKey = keyname;   //set the sortKey to the param passed
        $scope.reverse = !$scope.reverse; //if true make it false and vice versa
    }

    $scope.NewEmployee =
    {
        IDNUMBER: 0,
        EmpFirstName: '',
        EmpSurName: '',
        EmailID: '',
        PhoneNo: '',
        Position: '',
        EmployeeAddress: '',
        IsEmployeement: 0,
        EmploymentStart: '',
        EmployeeEnd: '',
        Notes: '',
        CompanyID: 1,
        IsActive: 1,
    }

    function GetEmployees() {
        $http.get("/api/Employee/GetEmployees").then(function (response) {
            debugger;
            $scope.Employees = response.data;
            $scope.EmployeeitemsPerPage = 10;
        });
    }

    GetEmployees();

    $scope.SaveEmployee = function () {
        debugger;
        $scope.NewEmployee.EmploymentStart = $("#datepickerEmploymentStart").val();
        $scope.NewEmployee.EmployeeEnd = $("#datepickerEmployeeEnd").val();

        if ($scope.NewEmployee.EmpFirstName == undefined || $scope.NewEmployee.EmpFirstName.length <= 2) {
            $scope.Errormessage = 'please enter valid Employee First Name';
            return;
        }

        if ($scope.NewEmployee.EmpSurName == undefined || $scope.NewEmployee.EmpSurName.length <= 2) {
            $scope.Errormessage = 'please enter valid Employee SurName';
            return;
        }

        if ($scope.NewEmployee.EmailID == undefined || $scope.NewEmployee.EmailID == "" || !validateEmail($scope.NewEmployee.EmailID)) {
            $scope.Errormessage = 'please enter valid Email';
            return;
        }

        if ($scope.NewEmployee.EmploymentStart == "" || $scope.NewEmployee.EmploymentStart == null) {
            $scope.Errormessage = 'please Enter valid Employment Start date';
            return;
        }

        if ($scope.NewEmployee.IsEmployeement == undefined || $scope.NewEmployee.IsEmployeement == true) {
            if ($scope.NewEmployee.EmployeeEnd == "" || $scope.NewEmployee.EmployeeEnd == null) {
                $scope.Errormessage = 'please Enter valid Employment End date';
                return;
            }
        }
        else { $scope.NewEmployee.EmployeeEnd = '2099-12-31' }

        $http.post("/api/Employee/CreateEmployee", $scope.NewEmployee, config).success(function (data, status, headers, config) {
            debugger;
            if (data.ResponseCode == 200 && data.ResponseGenID != null && data.ResponseGenID != 0) {
                $('#alertMessage').html(data.ResponseMessage);
                $('#alertPopup').modal();

                setTimeout(function () {
                    $('#alertPopup').modal('hide');
                }, 1500);

                GetEmployees();
                $scope.AddEmployee = !$scope.AddEmployee;
                $scope.EmployeeGrid = !$scope.EmployeeGrid;
            }
            else {
                $('#alertMessage').html(data.ResponseMessage);
                $('#alertPopup').modal();
            }

        });
    }

    //$scope.IsEmployeementcheckedchange = function () {
    //    debugger;
    //    if ($scope.NewEmployee.IsEmployeement == 1) { return 1 }
    //    else { return 0 }
    //}

    $scope.EditEmployee = function (EmpID) {
        $scope.EmployeePopupHeading = 'Update Employee';
        $scope.EmployeePopupBtn = 'Update Employee';
        $scope.AddEmployee = !$scope.AddEmployee;
        $scope.EmployeeGrid = !$scope.EmployeeGrid;
        $scope.Errormessage = '';
        debugger;
        $scope.filteredTicket = $filter('filter')($scope.Employees, { IDNUMBER: EmpID }, true);
        $scope.NewEmployee = $scope.filteredTicket[0];
        $scope.NewEmployee.IDNUMBER = $scope.filteredTicket[0].IDNUMBER;
        $scope.NewEmployee.EmploymentStart = $scope.NewEmployee.EmploymentStart.replace('T00:00:00', '');
        $scope.NewEmployee.EmployeeEnd = $scope.NewEmployee.EmployeeEnd.replace('T00:00:00', '');

        if ($scope.NewEmployee.IsEmployeement == 1) { $scope.NewEmployee.IsEmployeement = true } else { $scope.NewEmployee.IsEmployeement = false }
    }

    $scope.RemoveEmployeeID = '';

    $scope.DeleteEmployee = function (employeeID) {
        $('#confirmMessage').html("Are you sure you want to delete?");
        $('#confirmEmployeePopup').modal();
        $scope.RemoveEmployeeID = employeeID;
        return false;
    }

    $scope.RemoveEmployee = function () {
        debugger;
        $('#confirmEmployeePopup').modal('hide');
        $('#pleaseWaitDialog').modal();
        var EmpID = $scope.RemoveEmployeeID;
        $http.get("/api/Employee/DeleteEmployee?EmployeeID=" + EmpID).then(function (response) {
            debugger;
            if (response.data.ResponseCode == 200) {
                $('#pleaseWaitDialog').modal('hide');
                $('#alertMessage').html(response.data.ResponseMessage);
                $('#alertPopup').modal();

                setTimeout(function () {
                    $('#alertPopup').modal('hide');
                }, 1500);

                GetEmployees();
            }
            else {
                $('#pleaseWaitDialog').modal('hide');
                $('#alertMessage').html(response.data.ResponseMessage);
                $('#alertPopup').modal();
            }

        });

    }

    $scope.CloseAddEmployee = function () {
        $scope.AddEmployee = !$scope.AddEmployee;
        $scope.EmployeeGrid = !$scope.EmployeeGrid;
    }

    $scope.ClearEmployee = function () {
        $scope.EmployeePopupHeading = 'Add New Employee';
        $scope.EmployeePopupBtn = 'Save Employee';
        $scope.AddEmployee = !$scope.AddEmployee;
        $scope.EmployeeGrid = !$scope.EmployeeGrid;
        $scope.Errormessage = '';
        $scope.NewEmployee =
        {
            IDNUMBER: 0,
            EmpFirstName: '',
            EmpSurName: '',
            EmailID: '',
            PhoneNo: '',
            Position: '',
            EmployeeAddress: '',
            IsEmployeement: 0,
            EmploymentStart: '',
            EmployeeEnd: '',
            Notes: '',
            CompanyID: 1,
            IsActive: 1
        }
    }

}]);

CustomApp.controller('ExpenseController', ['$scope', '$http', '$filter', '$window', function ($scope, $http, $filter, $window) {
    $scope.message = 'Look! I am an about page.';
    $scope.Errormessage = '';

    $scope.ExpensePopupHeading = '';
    $scope.ExpensePopupBtn = '';

    $scope.AddExpense = false;
    $scope.ExpenseGrid = true;

    var config = {
        headers: {
            'Accept': 'application/json', 'Content-Type': 'application/json; charset=utf-8'
        }
    }

    $scope.SortExpense = function (keyname) {
        $scope.sortKey = keyname;   //set the sortKey to the param passed
        $scope.reverse = !$scope.reverse; //if true make it false and vice versa
    }

    var date = new Date();
    var ExpenseDate1 = date.getFullYear() + '-' + (date.getMonth() + 1) + '-' + date.getDate();

    $scope.NewExpense =
    {
        IDNUMBER: 0,
        ExpenseDate: ExpenseDate1,
        ExpenseName: '',
        PaidBy: 0,
        Wallet: 0,
        Item: '',
        ItemID: 0,
        ItemVarientID: 0,
        Currency: 'USD',
        Cost: 0,
        USDCost: 0,
        Note: '',
        IsActive: 1,
        CompanyID: 1,
    }

    function GetExpenses() {
        $http.get("/api/Expense/GetExpenses").then(function (response) {
            debugger;
            $scope.Expenses = response.data;
            $scope.ExpenseitemsPerPage = 10;
            convertCurrency(10.00, 'USD', 'INR')
        });
    }

    function GetUsers() {
        $http.get("/api/User/GetUsers").then(function (response) {
            debugger;
            $scope.Users = response.data;
        });
    }

    GetExpenses();
    GetUsers();

    $scope.SaveExpense = function () {
        debugger;
        $scope.NewExpense.ExpenseDate = $("#datepickerExpenseDate").val();

        if ($scope.NewExpense.ExpenseDate == "" || $scope.NewExpense.ExpenseDate == null) {
            $scope.Errormessage = 'please Enter valid Expense date';
            return;
        }

        if ($scope.NewExpense.ExpenseName == undefined || $scope.NewExpense.ExpenseName.length <= 2) {
            $scope.Errormessage = 'please enter valid Expense Name';
            return;
        }

        if ($scope.NewExpense.PaidBy == "" || $scope.NewExpense.PaidBy == 0 || $scope.NewExpense.PaidBy == "0" || $scope.NewExpense.PaidBy == null) {
            $scope.Errormessage = 'please Select User';
            return;
        }

        if ($scope.NewExpense.Item == "" || $scope.NewExpense.Item == null) {
            $scope.Errormessage = 'please Enter Item Name';
            return;
        }

        $http.post("/api/Expense/CreateExpense", $scope.NewExpense, config).success(function (data, status, headers, config) {
            debugger;
            if (data.ResponseCode == 200 && data.ResponseGenID != null && data.ResponseGenID != 0) {
                $('#alertMessage').html(data.ResponseMessage);
                $('#alertPopup').modal();

                setTimeout(function () {
                    $('#alertPopup').modal('hide');
                }, 1500);

                GetExpenses();
                $scope.AddExpense = !$scope.AddExpense;
                $scope.ExpenseGrid = !$scope.ExpenseGrid;
            }
            else {
                $('#alertMessage').html(data.ResponseMessage);
                $('#alertPopup').modal();
            }

        });
    }

    function convertCurrency() {
        debugger;
        var arrfxrates = localStorage.getItem('fxrates');
        $scope.fxrates = arrfxrates ? JSON.parse(arrfxrates) : [];
        //var fxratesLength = $scope.fxrates.length;
        var currDate = new Date();
        // Parse input
        var mStart = moment.utc($scope.fxrates.fxDateTime);
        var mEnd = moment.utc(currDate);
        // Calculate difference and create duration
        var dur = moment.duration(mEnd.diff(mStart));
        
        if ($scope.fxrates.length <= 0) {
            
            $http.get("https://openexchangerates.org/api/latest.json?app_id=f382c33c062844dbb23b7516061c6f0e").then(function (response) {
                //$scope.dataCurrency = response;
                //alert($scope.dataCurrency);
                debugger;
                if (typeof fx !== "undefined" && fx.rates) {
                    fx.rates = response.data.rates;
                    fx.base = response.data.base;
                } else {
                    // If not, apply to fxSetup global:
                    var fxSetup = {
                        rates: response.data.rates,
                        base: response.data.base
                    }
                }

                //$scope.dataCurrency = fx.convert(1, { from: 'USD', to: 'INR' })
                $scope.fxrates1 = fx.rates;
                $scope.fxrates1.fxDateTime = new Date();
                setSession('fxrates', JSON.stringify(fx.rates));
            });
        }
        else if (dur.hours() >= 1) {

            $http.get("https://openexchangerates.org/api/latest.json?app_id=f382c33c062844dbb23b7516061c6f0e").then(function (response) {
                //$scope.dataCurrency = response;
                //alert($scope.dataCurrency);
                debugger;
                if (typeof fx !== "undefined" && fx.rates) {
                    fx.rates = response.data.rates;
                    fx.base = response.data.base;
                } else {
                    // If not, apply to fxSetup global:
                    var fxSetup = {
                        rates: response.data.rates,
                        base: response.data.base
                    }
                }

                //$scope.dataCurrency = fx.convert(1, { from: 'USD', to: 'INR' })
                $scope.fxrates1 = fx.rates;
                $scope.fxrates1.fxDateTime = new Date();
                setSession('fxrates', JSON.stringify(fx.rates));
            });
        }
    }

    $scope.ChangeCurrency = function () {
        debugger;

        if ($scope.NewExpense.Cost == "" || $scope.NewExpense.Cost == 0 || $scope.NewExpense.Cost == "0" || $scope.NewExpense.Cost == null) {
            $scope.Errormessage = 'please Enter valid Expense Cost';
            return;
        }
        else { $scope.Errormessage = ''; }

        var From = $scope.NewExpense.Currency;
        var amount = $scope.NewExpense.Cost;
        fx.rates = $scope.fxrates;
        $scope.NewExpense.USDCost = fx.convert(amount, { from: From, to: 'USD' }).toFixed(3)
    }

    //$scope.IsExpensementcheckedchange = function () {
    //    debugger;
    //    if ($scope.NewExpense.IsExpensement == 1) { return 1 }
    //    else { return 0 }
    //}

    $scope.EditExpense = function (EmpID) {
        $scope.ExpensePopupHeading = 'Update Expense';
        $scope.ExpensePopupBtn = 'Update Expense';
        $scope.AddExpense = !$scope.AddExpense;
        $scope.ExpenseGrid = !$scope.ExpenseGrid;
        $scope.Errormessage = '';
        debugger;
        $scope.filteredTicket = $filter('filter')($scope.Expenses, { IDNUMBER: EmpID }, true);
        $scope.NewExpense = $scope.filteredTicket[0];
        $scope.NewExpense.IDNUMBER = $scope.filteredTicket[0].IDNUMBER;
        $scope.NewExpense.ExpenseDate = $scope.NewExpense.ExpenseDate.replace('T00:00:00', '');

    }

    $scope.RemoveExpenseID = '';

    $scope.DeleteExpense = function (ExpenseID) {
        $('#confirmMessage').html("Are you sure you want to delete?");
        $('#confirmExpensePopup').modal();
        $scope.RemoveExpenseID = ExpenseID;
        return false;
    }

    $scope.RemoveExpense = function () {
        debugger;
        $('#confirmExpensePopup').modal('hide');
        $('#pleaseWaitDialog').modal();
        var ExpID = $scope.RemoveExpenseID;
        $http.get("/api/Expense/DeleteExpense?ExpenseID=" + ExpID).then(function (response) {
            debugger;
            if (response.data.ResponseCode == 200) {
                $('#pleaseWaitDialog').modal('hide');
                $('#alertMessage').html(response.data.ResponseMessage);
                $('#alertPopup').modal();

                setTimeout(function () {
                    $('#alertPopup').modal('hide');
                }, 1500);

                GetExpenses();
            }
            else {
                $('#pleaseWaitDialog').modal('hide');
                $('#alertMessage').html(response.data.ResponseMessage);
                $('#alertPopup').modal();
            }

        });

    }

    $scope.CloseAddExpense = function () {
        $scope.AddExpense = !$scope.AddExpense;
        $scope.ExpenseGrid = !$scope.ExpenseGrid;
    }

    $scope.ClearExpense = function () {
        $scope.ExpensePopupHeading = 'Add New Expense';
        $scope.ExpensePopupBtn = 'Save Expense';
        $scope.AddExpense = !$scope.AddExpense;
        $scope.ExpenseGrid = !$scope.ExpenseGrid;
        $scope.Errormessage = '';
        $scope.NewExpense = {
            IDNUMBER: 0,
            ExpenseDate: ExpenseDate1,
            ExpenseName: '',
            PaidBy: 0,
            Wallet: 0,
            Item: '',
            ItemID: 0,
            ItemVarientID: 0,
            Currency: 'USD',
            Cost: 0,
            USDCost: 0,
            Note: '',
            IsActive: 1,
            CompanyID: 1,
        }
    }

}]);

CustomApp.controller('CategoriesController', ['$scope', '$http', '$filter', '$window', function ($scope, $http, $filter, $window) {
    $scope.message = 'Contact us! JK. This is just a demo.';
    $scope.Errormessage = '';

    $scope.CategoryPopupHeading = '';
    $scope.CategoryPopupBtn = '';

    $scope.AddCategory = false;
    $scope.CategoryGrid = true;

    var config = {
        headers: {
            'Accept': 'application/json', 'Content-Type': 'application/json; charset=utf-8'
        }
    }

    $scope.SortCategory = function (keyname) {
        $scope.sortKey = keyname;   //set the sortKey to the param passed
        $scope.reverse = !$scope.reverse; //if true make it false and vice versa
    }

    $scope.NewCategory =
    {
        IDNUMBER: 0,
        CompanyID: 1,
        UserType: 0,
        UserID: "",
        UserName: "",
        pswd: "",
        EmailID: "",
        MobileNo: "",
        BOD: '',
        IsActive: 1,
        IsSuperUser: 0,
    }

    function GetCategories() {
        $http.get("/api/Category/GetCategories").then(function (response) {
            debugger;
            $scope.Categories = response.data;
            $scope.CategoryitemsPerPage = 10;
        });
    }

    GetCategories();

    $scope.SaveCategory = function () {
        debugger;

        if ($scope.NewCategory.CategoryName == undefined || $scope.NewCategory.CategoryName.length <= 2) {
            $scope.Errormessage = 'please enter valid Category';
            return;
        }

        $http.post("/api/Category/CreateCategory", $scope.NewCategory, config).success(function (data, status, headers, config) {
            debugger;
            if (data.ResponseCode == 200 && data.ResponseGenID != null && data.ResponseGenID != 0) {
                $('#alertMessage').html(data.ResponseMessage);
                $('#alertPopup').modal();

                setTimeout(function () {
                    $('#alertPopup').modal('hide');
                }, 1500);

                GetCategories();
                $scope.AddCategory = !$scope.AddCategory;
                $scope.CategoryGrid = !$scope.CategoryGrid;
            }
            else {
                $('#alertMessage').html(data.ResponseMessage);
                $('#alertPopup').modal();
            }

        });
    }

    $scope.EditCategory = function (CatID) {
        $scope.CategoryPopupHeading = 'Update Category';
        $scope.CategoryPopupBtn = 'Update Category';
        $scope.AddCategory = !$scope.AddCategory;
        $scope.CategoryGrid = !$scope.CategoryGrid;
        $scope.Errormessage = '';
        debugger;
        $scope.filteredTicket = $filter('filter')($scope.Categories, { IDNUMBER: CatID }, true);
        $scope.NewCategory = $scope.filteredTicket[0];
        $scope.NewCategory.IDNUMBER = $scope.filteredTicket[0].IDNUMBER;
    }

    $scope.RemoveCategoryID = '';

    $scope.DeleteCategory = function (employeeID) {
        $('#confirmMessage').html("Are you sure you want to delete?");
        $('#confirmCategoryPopup').modal();
        $scope.RemoveCategoryID = employeeID;
        return false;
    }

    $scope.RemoveCategory = function () {
        debugger;
        $('#confirmCategoryPopup').modal('hide');
        $('#pleaseWaitDialog').modal();
        var CatID = $scope.RemoveCategoryID;
        $http.get("/api/Category/DeleteCategory?CategoryID=" + CatID).then(function (response) {
            debugger;
            if (response.data.ResponseCode == 200) {
                $('#pleaseWaitDialog').modal('hide');
                $('#alertMessage').html(response.data.ResponseMessage);
                $('#alertPopup').modal();

                setTimeout(function () {
                    $('#alertPopup').modal('hide');
                }, 1500);

                GetCategories();
            }
            else {
                $('#pleaseWaitDialog').modal('hide');
                $('#alertMessage').html(response.data.ResponseMessage);
                $('#alertPopup').modal();
            }

        });

    }

    $scope.CloseAddCategory = function () {
        $scope.AddCategory = !$scope.AddCategory;
        $scope.CategoryGrid = !$scope.CategoryGrid;
    }

    $scope.ClearCategory = function () {
        $scope.CategoryPopupHeading = 'Add New Category';
        $scope.CategoryPopupBtn = 'Save Category';
        $scope.AddCategory = !$scope.AddCategory;
        $scope.CategoryGrid = !$scope.CategoryGrid;
        $scope.Errormessage = '';
        $scope.NewCategory =
        {
            IDNUMBER: 0,
            CompanyID: 1,
            UserType: 0,
            UserID: "",
            UserName: "",
            pswd: "",
            EmailID: "",
            MobileNo: "",
            BOD: '',
            IsActive: 1,
            IsSuperUser: 0,
        }
    }

}]);

CustomApp.controller('WarehouseController', ['$scope', '$http', '$filter', '$window', function ($scope, $http, $filter, $window) {
    $scope.message = 'Contact us! JK. This is just a demo.';
    $scope.Errormessage = '';

    $scope.WarehousePopupHeading = '';
    $scope.WarehousePopupBtn = '';

    $scope.AddWarehouse = false;
    $scope.WarehouseGrid = true;

    var config = {
        headers: {
            'Accept': 'application/json', 'Content-Type': 'application/json; charset=utf-8'
        }
    }

    $scope.SortWarehouse = function (keyname) {
        $scope.sortKey = keyname;   //set the sortKey to the param passed
        $scope.reverse = !$scope.reverse; //if true make it false and vice versa
    }

    $scope.NewWarehouse =
    {
        IDNUMBER: 0,
        CompanyID: 1,
        UserType: 0,
        UserID: "",
        UserName: "",
        pswd: "",
        EmailID: "",
        MobileNo: "",
        BOD: '',
        IsActive: 1,
        IsSuperUser: 0,
    }

    function GetWarehouses() {
        $http.get("/api/Warehouse/GetWarehouses").then(function (response) {
            debugger;
            $scope.Warehouses = response.data;
            $scope.WarehouseitemsPerPage = 10;
        });
    }

    GetWarehouses();

    $scope.SaveWarehouse = function () {
        debugger;

        if ($scope.NewWarehouse.WarehouseName == undefined || $scope.NewWarehouse.WarehouseName.length <= 2) {
            $scope.Errormessage = 'please enter valid Warehouse Name';
            return;
        }

        if ($scope.NewWarehouse.Address == undefined || $scope.NewWarehouse.Address.length <= 2) {
            $scope.Errormessage = 'please enter valid Warehouse Address';
            return;
        }

        $http.post("/api/Warehouse/Createwarehouse", $scope.NewWarehouse, config).success(function (data, status, headers, config) {
            debugger;
            if (data.ResponseCode == 200 && data.ResponseGenID != null && data.ResponseGenID != 0) {
                $('#alertMessage').html(data.ResponseMessage);
                $('#alertPopup').modal();

                setTimeout(function () {
                    $('#alertPopup').modal('hide');
                }, 1500);

                GetWarehouses();
                $scope.AddWarehouse = !$scope.AddWarehouse;
                $scope.WarehouseGrid = !$scope.WarehouseGrid;
            }
            else {
                $('#alertMessage').html(data.ResponseMessage);
                $('#alertPopup').modal();
            }

        });
    }

    $scope.EditWarehouse = function (WarID) {
        $scope.WarehousePopupHeading = 'Update Warehouse';
        $scope.WarehousePopupBtn = 'Update Warehouse';
        $scope.AddWarehouse = !$scope.AddWarehouse;
        $scope.WarehouseGrid = !$scope.WarehouseGrid;
        $scope.Errormessage = '';
        debugger;
        $scope.filteredTicket = $filter('filter')($scope.Warehouses, { IDNUMBER: WarID }, true);
        $scope.NewWarehouse = $scope.filteredTicket[0];
        $scope.NewWarehouse.IDNUMBER = $scope.filteredTicket[0].IDNUMBER;
    }

    $scope.RemoveWarehouseID = '';

    $scope.DeleteWarehouse = function (warehouseID) {
        $('#confirmMessage').html("Are you sure you want to delete?");
        $('#confirmSWarehousePopup').modal();
        $scope.RemoveWarehouseID = warehouseID;
        return false;
    }

    $scope.RemoveWarehouse = function () {
        debugger;
        $('#confirmSWarehousePopup').modal('hide');
        $('#pleaseWaitDialog').modal();
        var WarID = $scope.RemoveWarehouseID;
        $http.get("/api/Warehouse/DeleteWarehouse?WarehouseID=" + WarID).then(function (response) {
            debugger;
            if (response.data.ResponseCode == 200) {
                $('#pleaseWaitDialog').modal('hide');
                $('#alertMessage').html(response.data.ResponseMessage);
                $('#alertPopup').modal();

                setTimeout(function () {
                    $('#alertPopup').modal('hide');
                }, 1500);

                GetWarehouses();
            }
            else {
                $('#pleaseWaitDialog').modal('hide');
                $('#alertMessage').html(response.data.ResponseMessage);
                $('#alertPopup').modal();
            }

        });

    }

    $scope.CloseAddWarehouse = function () {
        $scope.AddWarehouse = !$scope.AddWarehouse;
        $scope.WarehouseGrid = !$scope.WarehouseGrid;
    }

    $scope.ClearWarehouse = function () {
        $scope.WarehousePopupHeading = 'Add New Warehouse';
        $scope.WarehousePopupBtn = 'Save Warehouse';
        $scope.AddWarehouse = !$scope.AddWarehouse;
        $scope.WarehouseGrid = !$scope.WarehouseGrid;
        $scope.Errormessage = '';
        $scope.NewWarehouse =
        {
            IDNUMBER: 0,
            CompanyID: 1,
            UserType: 0,
            UserID: "",
            UserName: "",
            pswd: "",
            EmailID: "",
            MobileNo: "",
            BOD: '',
            IsActive: 1,
            IsSuperUser: 0,
        }
    }

}]);

CustomApp.controller('ProductController', ['$scope', '$http', '$filter', '$window', 'Upload', '$timeout', function ($scope, $http, $filter, $window, Upload, $timeout) {
    $scope.message = 'Contact us! JK. This is just a demo.';
    $scope.Errormessage = '';

    $scope.ProductPopupHeading = 'Add New Warehouse';
    $scope.ProductPopupBtn = 'Save Warehouse';

    $scope.AddProduct = false;
    $scope.ProductGrid = true;

    var config = {
        headers: {
            'Accept': 'application/json', 'Content-Type': 'application/json; charset=utf-8'
        }
    }

    $scope.SortProduct = function (keyname) {
        $scope.sortKey = keyname;   //set the sortKey to the param passed
        $scope.reverse = !$scope.reverse; //if true make it false and vice versa
    }

    $scope.NewProduct =
    {
        IDNUMBER: 0,
        CompanyID: 1,
        ItemName: '',
        CategoryID: 0,
        Description: '',
        inchLength: '',
        inchHeight: '',
        inchWidth: '',
        cmLength: '',
        cmHeight: '',
        cmWidth: '',
        kgWeight: '',
        lbsWeight: '',
        Note: '',
        IsActive: 1,
        IsSuperUser: 0,
        IsImage:0,

        ItemVarients: [
      { IDNUMBER: '', CompanyID: 1, ItemImage: false, Color: '', Size: '', Inventory: '', WarehouseID: '', Cost: '', SKU: '', UPC: '', IsActive: 1 }
        ]
    }

    function GetCategories() {
        $http.get("/api/Category/GetCategories").then(function (response) {
            debugger;
            $scope.Categories = response.data;
        });
    }

    function GetWarehouses() {
        $http.get("/api/Warehouse/GetWarehouses").then(function (response) {
            debugger;
            $scope.Warehouses = response.data;
        });
    }

    debugger;
    //var vm = this;

    $scope.ItemVarients = [
      { IDNUMBER: '', CompanyID: 1, ItemImage: false, Color: '', Size: '', Inventory: '', WarehouseID: '', Cost: '', SKU: '', UPC: '', IsActive: 1 }
    ]

    $scope.add = function () {
        $scope.ItemVarients.push({ IDNUMBER: '', CompanyID: 1, ItemImage: false, Color: '', Size: '', Inventory: '', WarehouseID: '', Cost: '', SKU: '', UPC: '', IsActive: 1 });
    }
    $scope.remove = function (index) {
        $scope.ItemVarients.splice(index, 1);
    }

    function GetProducts() {
        $http.get("/api/Product/GetProducts").then(function (response) {
            debugger;
            $scope.Products = response.data;
            $scope.ProductitemsPerPage = 10;
        });
    }
    GetCategories();
    GetProducts();
    GetWarehouses();

    $scope.SaveProduct = function () {
        debugger;
        if ($scope.NewProduct.ItemName == '' || $scope.NewProduct.ItemName == null) {
            $("#ItemName").css("border-color", "red");
            return;
        }
        else {
            $("#ItemName").css("border-color", "#d2d6de");
        }
        if ($scope.NewProduct.CategoryID == '' || $scope.NewProduct.CategoryID == null) {
            $("#CategoryID").css("border-color", "red");
            return;
        }
        else {
            $("#CategoryID").css("border-color", "#d2d6de");
        }
        if ($scope.NewProduct.kgWeight == '' || $scope.NewProduct.kgWeight == null) {
            $("#kgWeight").css("border-color", "red");
            return;
        }
        else {
            $("#kgWeight").css("border-color", "#d2d6de");
        }
        if ($scope.NewProduct.lbsWeight == '' || $scope.NewProduct.lbsWeight == null) {
            $("#lbsWeight").css("border-color", "red");
            return;
        }
        else {
            $("#lbsWeight").css("border-color", "#d2d6de");
        }
        if ($scope.NewProduct.IsImage == 1) {
            $scope.NewProduct.ItemImage = $scope.ProductImageURLTemp;
        }
       
        $scope.NewProduct.ItemVarients = $scope.ItemVarients;
        $http.post("/api/Product/CreateProduct", $scope.NewProduct, config).success(function (data, status, headers, config) {
            debugger;
            if (data.ResponseCode == 200 && data.ResponseGenID != null && data.ResponseGenID != 0) {
                $('#alertMessage').html(data.ResponseMessage);
                $('#alertPopup').modal();

                setTimeout(function () {
                    $('#alertPopup').modal('hide');
                }, 1500);

                GetProducts();
                $scope.AddProduct = !$scope.AddProduct;
                $scope.ProductGrid = !$scope.ProductGrid;
            }
            else {
                $('#alertMessage').html(data.ResponseMessage);
                $('#alertPopup').modal();
            }

        });
    }

    $scope.EditProduct = function (PrID) {
        $scope.ProductPopupHeading = 'Update Product';
        $scope.ProductPopupBtn = 'Update Product';
        $scope.AddProduct = !$scope.AddProduct;
        $scope.ProductGrid = !$scope.ProductGrid;
        $scope.Errormessage = '';
        debugger;
        $scope.filteredTicket = $filter('filter')($scope.Products, { IDNUMBER: PrID }, true);
        $scope.NewProduct = $scope.filteredTicket[0];
        $scope.NewProduct.IDNUMBER = $scope.filteredTicket[0].IDNUMBER;
        $scope.ProductImageURL = $scope.NewProduct.ItemImage;
        $scope.ItemVarients = $scope.NewProduct.ItemVarients;

        if ($scope.ItemVarients == null) {
            $scope.ItemVarients = [{ IDNUMBER: '', CompanyID: 1, ItemImage: false, Color: '', Size: '', Inventory: '', WarehouseID: '', Cost: '', SKU: '', UPC: '', IsActive: 1 }
            ]
        }
    }

    $scope.DeleteProduct = function (PrID) {
        //debugger;
        //$http.get("/api/Warehouse/DeleteWarehouse?WarehouseID=" + PrID).then(function (response) {
        //    debugger;
        //    if (response.data.ResponseCode == 200) {
        //        $('#alertMessage').html(response.data.ResponseMessage);
        //        $('#alertPopup').modal();
        //        GetWarehouses();
        //    }
        //    else {
        //        $('#alertMessage').html(response.data.ResponseMessage);
        //        $('#alertPopup').modal();
        //    }

        //});

    }

    $scope.CloseAddProduct = function () {
        $scope.AddProduct = !$scope.AddProduct;
        $scope.ProductGrid = !$scope.ProductGrid;
    }

    $scope.upload = [];
    $scope.ProductImageURL = '../dist/img/user-image.png';

    $scope.uploadWebSiteBannerFiles = function (file, errFiles) {
        debugger;
        $scope.f = file;
        $scope.errFile = errFiles && errFiles[0];
        if (file) {
            file.upload = Upload.upload({
                url: '/api/Files/Upload',
                data: { file: file }
            });

            file.upload.then(function (response) {
                $scope.ProductImageURL = response.data.returnData;
                $scope.ProductImageURLTemp = $scope.ProductImageURL;
                $scope.ProductImageURL = '/TempFiles/' + $scope.ProductImageURL;
                $scope.NewProduct.IsImage = 1;
                $timeout(function () {
                    file.result = response.data;

                });
            }, function (response) {
                if (response.status > 0)
                    $scope.errorMsg = response.status + ': ' + response.data;
            }, function (evt) {
                file.progress = Math.min(100, parseInt(100.0 *
                                         evt.loaded / evt.total));
            });
        }
    }

    $scope.ClearProduct = function () {
        $scope.ProductImageURL = '../dist/img/user-image.png';
        $scope.ProductPopupHeading = 'Add New Product';
        $scope.ProductPopupBtn = 'Save Product';
        $scope.AddProduct = !$scope.AddProduct;
        $scope.ProductGrid = !$scope.ProductGrid;
        $scope.Errormessage = '';
        $scope.NewProduct =
        {
            IDNUMBER: 0,
            CompanyID: 1,
            ItemName: '',
            CategoryID: 0,
            Description: '',
            inchLength: '',
            inchHeight: '',
            inchWidth: '',
            cmLength: '',
            cmHeight: '',
            cmWidth: '',
            kgWeight: '',
            lbsWeight: '',
            Note: '',
            IsActive: 1,
            IsSuperUser: 0,
            IsImage: 0,

            ItemVarients: [
      { IDNUMBER: '', CompanyID: 1, ItemImage: false, Color: '', Size: '', Inventory: '', WarehouseID: '', Cost: '', SKU: '', UPC: '', IsActive: 1 }
            ]
        }
        $scope.ItemVarients = $scope.NewProduct.ItemVarients;
    }

}]);

CustomApp.controller('PurchaseController', ['$scope', '$http', '$filter', '$window', function ($scope, $http, $filter, $window) {
    $scope.message = 'Contact us! JK. This is just a demo.';
    $scope.Errormessage = '';

    $scope.AddPurchase = false;
    $scope.PurchaseGrid = true;
    $scope.PrintPurchase = false;
    $scope.PrintPurchaseshow = false;

    var config = {
        headers: {
            'Accept': 'application/json', 'Content-Type': 'application/json; charset=utf-8'
        }
    }

    $scope.SortPurchase = function (keyname) {
        $scope.sortKey = keyname;   //set the sortKey to the param passed
        $scope.reverse = !$scope.reverse; //if true make it false and vice versa
    }

    function GetLastSalesID() {
        $http.get("/api/Sales/GetLastSalesID").then(function (response) {
            debugger;
        });
    }

    function GetLastPurchaseID() {
        $http.get("/api/Purchase/GetLastPurchaseID").then(function (response) {
            debugger;
            var LastPurchaseID = response.data;
            LastPurchaseID = LastPurchaseID.replace(/[""]+/g, "");
            $scope.LastPurchaseID = LastPurchaseID;
            $scope.NewPurchase.PONo = 'CERPPO' + LastPurchaseID;
        });
    }
    GetLastPurchaseID();

    var date = new Date();
    var PODate1 = date.getFullYear() + '-' + (date.getMonth() + 1) + '-' + date.getDate();


    $scope.NewPurchase =
    {
        IDNUMBER: 0,
        CompanyID: 1,
        PONo: '',
        PODate: PODate1,
        SupplierID: '',
        ShippingName: '',
        ShippingAddress: '',
        ShippingCost: '',
        PaymentType: 1,
        TotalQty: '',
        SubTotal: '',
        Currency: '',
        Deposite: '',
        BBShippment: '',
        Incoterms: '',
        IsActive: 1,
        IsSuperUser: 0,

        Supplier: [],
        PurchaseDetails: [],
        ItemVarients: []
    };

    GetLastPurchaseID();

    $scope.NewItemVarient = [];

    $scope.NewPurchase.SubTotal = 0;
    $scope.NewPurchase.Total = 0;
    $scope.NewPurchase.FullTotal = 0;
    $scope.NewPurchase.ShippingCost = 0;
    $scope.NewPurchase.Deposite = 0;
    $scope.NewPurchase.BBShippment = 0;
    $scope.NewPurchase.TotalQty = 0;

    function GetPurchases() {
        $http.get("/api/Purchase/GetPurchases").then(function (response) {
            debugger;
            $scope.Purchases = response.data;
            $scope.PurchaseitemsPerPage = 10;
        });
    }

    function GetSuppliers() {
        $http.get("/api/Supplier/GetSuppliers").then(function (response) {
            debugger;
            $scope.Suppliers = response.data;
        });
    }

    function GetItemVarients() {
        $http.get("/api/ItemVarient/GetItemVarients").then(function (response) {
            debugger;
            $scope.ItemVarients = response.data;
        });
    }

    GetSuppliers();
    GetItemVarients();
    GetPurchases();

    $scope.supplierChange = function () {
        debugger;
        var SuppID = $scope.NewPurchase.SupplierID;
        $scope.filteredSuppliers = $filter('filter')($scope.Suppliers, { IDNUMBER: SuppID }, true);
        $scope.NewPurchase.Supplier = $scope.filteredSuppliers[0];
        $scope.NewPurchase.ShippingAddress = $scope.NewPurchase.Supplier.ShippingAddress;

    }

    $scope.AddItemVarient = function () {
        debugger;

        if ($scope.NewItemVarient.ItemVarientID1 == undefined || $scope.NewItemVarient.ItemVarientID1 < 1) {
            $("#NewItemVarientID").css("border-color", "red");
            return;
        }
        else {
            $("#NewItemVarientID").css("border-color", "#d2d6de");
        }

        if ($scope.NewItemVarient.Qty1 == undefined || $scope.NewItemVarient.Qty1.length < 1) {
            $("#NewItemVarientQty").css("border-color", "red");
            return;
        }
        else {
            $("#NewItemVarientQty").css("border-color", "#d2d6de");
        }

        if ($scope.NewItemVarient.Price1 == undefined || $scope.NewItemVarient.Price1.length < 1) {
            $("#NewItemVarientPrice").css("border-color", "red");
            return;
        }
        else {
            $("#NewItemVarientPrice").css("border-color", "#d2d6de");
        }

        var ItemVarientID = $scope.NewItemVarient.ItemVarientID1;
        var Qty = $scope.NewItemVarient.Qty1;
        var Price = $scope.NewItemVarient.Price1;
        $scope.filteredItemVarients = $filter('filter')($scope.ItemVarients, { IDNUMBER: ItemVarientID }, true);
        $scope.NewItemVarient = $scope.filteredItemVarients[0];
        $scope.NewItemVarient.Qty = Qty;
        $scope.NewItemVarient.Price = Price;
        $scope.NewItemVarient.TotalAmount = Qty * Price;
        $scope.NewItemVarient.ItemVarientID = ItemVarientID;
        $scope.NewPurchase.ItemVarients.push($scope.NewItemVarient);
        ItemsTotalQtyAmount();
    }
    function ItemsTotalQtyAmount() {

        debugger;
        $scope.NewPurchase.SubTotal = 0;
        $scope.NewPurchase.Total = 0;
        $scope.NewPurchase.FullTotal = 0;
        $scope.NewPurchase.TotalQty = 0;
        jQuery.each($scope.NewPurchase.ItemVarients, function (i, val) {
            $scope.NewPurchase.SubTotal = parseFloat($scope.NewPurchase.SubTotal) + parseFloat($scope.NewPurchase.ItemVarients[i].TotalAmount);
            $scope.NewPurchase.TotalQty = parseFloat($scope.NewPurchase.TotalQty) + parseFloat($scope.NewPurchase.ItemVarients[i].Qty);
        });

        $scope.NewPurchase.FullTotal = parseFloat($scope.NewPurchase.SubTotal) + parseFloat($scope.NewPurchase.ShippingCost);
        $scope.NewPurchase.Total = $scope.NewPurchase.FullTotal;

        var TotalPer = parseFloat(parseFloat($scope.NewPurchase.Total) * parseFloat($scope.NewPurchase.Deposite) / 100)
        $scope.NewPurchase.Total = parseFloat($scope.NewPurchase.Total) - TotalPer;
        $scope.NewPurchase.Total = parseFloat($scope.NewPurchase.Total) - parseFloat($scope.NewPurchase.BBShippment);

        $scope.NewPurchase.PayInWords = withDecimal(parseFloat($scope.NewPurchase.FullTotal));
    }

    $scope.UpdateAmount = function (Index) {
        debugger
        $scope.NewPurchase.ItemVarients[Index].TotalAmount = $scope.NewPurchase.ItemVarients[Index].Qty * $scope.NewPurchase.ItemVarients[Index].Price;
        ItemsTotalQtyAmount();

    }

    $scope.UpdateQtyAmount = function () {
        ItemsTotalQtyAmount();
    }

    function withDecimal(n) {
        var nums = n.toString().split('.')
        var whole = convertNumberToWords(nums[0])
        if (nums.length == 2) {
            var fraction = convertNumberToWords(nums[1])
            return whole + 'and ' + fraction;
        } else {
            return whole;
        }
    }

    $scope.remove = function (index) {
        $scope.NewPurchase.ItemVarients.splice(index, 1);
    }

    $scope.SavePurchase = function () {
        debugger;

        if ($scope.NewPurchase.SupplierID == undefined || $scope.NewPurchase.SupplierID < 1) {
            $("#NewPurchaseSupplierID").css("border-color", "red");
            return;
        }
        else {
            $("#NewPurchaseSupplierID").css("border-color", "#d2d6de");
        }

        if ($scope.NewPurchase.ShippingName == undefined || $scope.NewPurchase.ShippingName < 2) {
            $("#NewPurchaseShippingName").css("border-color", "red");
            return;
        }
        else {
            $("#NewPurchaseShippingName").css("border-color", "#d2d6de");
        }

        if ($scope.NewPurchase.ShippingAddress == undefined || $scope.NewPurchase.ShippingAddress < 5) {
            $("#NewPurchaseShippingAddress").css("border-color", "red");
            return;
        }
        else {
            $("#NewPurchaseShippingAddress").css("border-color", "#d2d6de");
        }

        if ($scope.NewPurchase.ItemVarients == undefined || $scope.NewPurchase.ItemVarients.length < 1) {
            $('#alertMessage').html("Please Select Items!!!");
            $('#alertPopup').modal();
            return;
        }

        $scope.NewPurchase.PurchaseDetails = $scope.NewPurchase.ItemVarients;
        $http.post("/api/Purchase/CreatePurchase", $scope.NewPurchase, config).success(function (data, status, headers, config) {
            debugger;
            if (data.ResponseCode == 200 && data.ResponseGenID != null && data.ResponseGenID != 0) {
                $('#alertMessage').html(data.ResponseMessage);
                $('#alertPopup').modal();

                setTimeout(function () {
                    $('#alertPopup').modal('hide');
                }, 1500);

                GetPurchases();
                //printContent("PurchaseInvoice");
                $scope.AddPurchase = !$scope.AddPurchase;
                $scope.PurchaseGrid = !$scope.PurchaseGrid;
                $scope.PrintPurchase = !$scope.PrintPurchase;
                $scope.PrintPurchaseshow = true;
                //$scope.ClearPurchase();
            }
            else {
                $('#alertMessage').html(data.ResponseMessage);
                $('#alertPopup').modal();
            }

        });
    }

    $scope.InvoicePurchase = function () {
        debugger;
        //$scope.PrintPurchaseshow = false;
        //printContent("PurchaseInvoice");
        PrintPurchaseInvoice();

    }

    function PrintPurchaseInvoice() {
        html2canvas(document.getElementById('PurchaseInvoice'), {
            onrendered: function (canvas) {
                var data = canvas.toDataURL();
                var docDefinition = {
                    content: [{
                        image: data,
                        fit: [510, 761],
                    }]
                };
                pdfMake.createPdf(docDefinition).download("PurchaseInvoice.pdf");
            }
        });
    }

    $scope.DownloadPurchaseInvoice = function (PurID) {
        debugger;
        $scope.filteredTicket = $filter('filter')($scope.Purchases, { IDNUMBER: PurID }, true);
        $scope.NewPurchase = $scope.filteredTicket[0];
        $scope.NewPurchase.IDNUMBER = $scope.filteredTicket[0].IDNUMBER;
        $scope.supplierChange();

        $scope.NewPurchase.ItemVarients = $scope.NewPurchase.PurchaseDetails;

        $scope.NewPurchase.FullTotal = parseFloat($scope.NewPurchase.SubTotal) + parseFloat($scope.NewPurchase.ShippingCost);
        $scope.NewPurchase.Total = $scope.NewPurchase.FullTotal;

        PrintPurchaseInvoice();
    };

    $scope.PurchaseInvoicePreview = function (PurID) {
        debugger;
        //$scope.AddPurchase = !$scope.AddPurchase;
        $scope.PurchaseGrid = !$scope.PurchaseGrid;
        $scope.PrintPurchase = !$scope.PrintPurchase;
        $scope.Errormessage = '';
        $scope.filteredTicket = $filter('filter')($scope.Purchases, { IDNUMBER: PurID }, true);
        $scope.NewPurchase = $scope.filteredTicket[0];
        $scope.NewPurchase.IDNUMBER = $scope.filteredTicket[0].IDNUMBER;
        $scope.supplierChange();

        $scope.NewPurchase.ItemVarients = $scope.NewPurchase.PurchaseDetails;

        $scope.NewPurchase.FullTotal = parseFloat($scope.NewPurchase.SubTotal) + parseFloat($scope.NewPurchase.ShippingCost);
        $scope.NewPurchase.Total = $scope.NewPurchase.FullTotal;
    }

    $scope.CloseAddPurchase = function () {
        $scope.AddPurchase = !$scope.AddPurchase;
        $scope.PurchaseGrid = !$scope.PurchaseGrid;
        $scope.PrintPurchase = false;
    }

    $scope.ClosePurchasePreview = function () {
        $scope.AddPurchase = false;
        $scope.PurchaseGrid = true;
        $scope.PrintPurchase = false;
    }

    $scope.ClearPurchase = function () {
        $scope.AddPurchase = !$scope.AddPurchase;
        $scope.PurchaseGrid = !$scope.PurchaseGrid;
        $scope.PrintPurchase = false;
        $scope.Errormessage = '';
        $scope.NewPurchase =
        {
            IDNUMBER: 0,
            CompanyID: 1,
            PONo: 0,
            PODate: PODate1,
            SupplierID: '',
            ShippingName: '',
            ShippingAddress: '',
            ShippingCost: '',
            PaymentType: 1,
            TotalQty: '',
            SubTotal: '',
            Currency: '',
            Deposite: '',
            BBShippment: '',
            Incoterms: '',
            IsActive: 1,
            IsSuperUser: 0,

            Supplier: [],
            PurchaseDetails: [],
            ItemVarients: []
        }

        $scope.NewPurchase.SubTotal = 0;
        $scope.NewPurchase.Total = 0;
        $scope.NewPurchase.FullTotal = 0;
        $scope.NewPurchase.ShippingCost = 0;
        $scope.NewPurchase.Deposite = 0;
        $scope.NewPurchase.BBShippment = 0;
        $scope.NewPurchase.TotalQty = 0;
        GetLastPurchaseID();
    }

}]);

CustomApp.controller('SalesContractController', ['$scope', '$http', '$filter', '$window', function ($scope, $http, $filter, $window) {
    $scope.message = 'Contact us! JK. This is just a demo.';
    $scope.Errormessage = '';

    $scope.AddSales = false;
    $scope.SalesGrid = true;
    $scope.PrintSales = false;
    $scope.PrintSalesshow = false;

    var config = {
        headers: {
            'Accept': 'application/json', 'Content-Type': 'application/json; charset=utf-8'
        }
    }

    $scope.SortSalesContract = function (keyname) {
        $scope.sortKey = keyname;   //set the sortKey to the param passed
        $scope.reverse = !$scope.reverse; //if true make it false and vice versa
    }

    function GetLastSalesContractID() {
        $http.get("/api/SalesContract/GetLastSalesContractID").then(function (response) {
            debugger;
            var LastSalesContractID = response.data;
            LastSalesContractID = LastSalesContractID.replace(/[""]+/g, "");
            $scope.LastSalesContractID = LastSalesContractID;
            $scope.NewSalesContract.SCNo = 'CERPSO' + LastSalesContractID;
        });
    }

    var date = new Date();
    var SCDate1 = date.getFullYear() + '-' + (date.getMonth() + 1) + '-' + date.getDate();


    $scope.NewSalesContract =
    {
        IDNUMBER: 0,
        CompanyID: 1,
        SCNo: '',
        SCDate: SCDate1,
        SupplierID: '',
        ShippingName: '',
        ShippingAddress: '',
        ShippingCost: '',
        PaymentType: 1,
        TotalQty: '',
        SubTotal: '',
        Currency: '',
        Deposite: '',
        BBShippment: '',
        Incoterms: '',
        IsActive: 1,
        IsSuperUser: 0,

        Customer: [],
        SalesContractDetails: [],
        ItemVarients: []
    };

    GetLastSalesContractID();

    $scope.NewItemVarient = [];

    $scope.NewSalesContract.SubTotal = 0;
    $scope.NewSalesContract.Total = 0;
    $scope.NewSalesContract.FullTotal = 0;
    $scope.NewSalesContract.ShippingCost = 0;
    $scope.NewSalesContract.Deposite = 0;
    $scope.NewSalesContract.BBShippment = 0;
    $scope.NewSalesContract.TotalQty = 0;

    function GetSalesContract() {
        $http.get("/api/SalesContract/GetSalesContract").then(function (response) {
            debugger;
            $scope.SalesContract = response.data;
            $scope.SalesContractitemsPerPage = 10;
        });
    }

    function GetCustomers() {
        $http.get("/api/Customer/GetCustomers").then(function (response) {
            debugger;
            $scope.Customers = response.data;
        });
    }

    function GetItemVarients() {
        $http.get("/api/ItemVarient/GetItemVarients").then(function (response) {
            debugger;
            $scope.ItemVarients = response.data;
        });
    }

    GetCustomers();
    GetItemVarients();
    GetSalesContract();

    $scope.CustomerChange = function () {
        debugger;
        var CustID = $scope.NewSalesContract.CustomerID;
        $scope.filteredCustomers = $filter('filter')($scope.Customers, { IDNUMBER: CustID }, true);
        $scope.NewSalesContract.Customer = $scope.filteredCustomers[0];
        $scope.NewSalesContract.ShippingAddress = $scope.NewSalesContract.Customer.ShippingAddress;

    }

    $scope.AddItemVarient = function () {
        debugger;

        if ($scope.NewItemVarient.ItemVarientID1 == undefined || $scope.NewItemVarient.ItemVarientID1 < 1) {
            $("#NewItemVarientID").css("border-color", "red");
            return;
        }
        else {
            $("#NewItemVarientID").css("border-color", "#d2d6de");
        }

        if ($scope.NewItemVarient.Qty1 == undefined || $scope.NewItemVarient.Qty1.length < 1) {
            $("#NewItemVarientQty").css("border-color", "red");
            return;
        }
        else {
            $("#NewItemVarientQty").css("border-color", "#d2d6de");
        }

        if ($scope.NewItemVarient.Price1 == undefined || $scope.NewItemVarient.Price1.length < 1) {
            $("#NewItemVarientPrice").css("border-color", "red");
            return;
        }
        else {
            $("#NewItemVarientPrice").css("border-color", "#d2d6de");
        }

        var ItemVarientID = $scope.NewItemVarient.ItemVarientID1;
        var Qty = $scope.NewItemVarient.Qty1;
        var Price = $scope.NewItemVarient.Price1;
        $scope.filteredItemVarients = $filter('filter')($scope.ItemVarients, { IDNUMBER: ItemVarientID }, true);
        $scope.NewItemVarient = $scope.filteredItemVarients[0];
        $scope.NewItemVarient.Qty = Qty;
        $scope.NewItemVarient.Price = Price;
        $scope.NewItemVarient.TotalAmount = Qty * Price;
        $scope.NewItemVarient.ItemVarientID = ItemVarientID;
        $scope.NewSalesContract.ItemVarients.push($scope.NewItemVarient);
        ItemsTotalQtyAmount();
    }
    function ItemsTotalQtyAmount() {

        debugger;
        $scope.NewSalesContract.SubTotal = 0;
        $scope.NewSalesContract.Total = 0;
        $scope.NewSalesContract.FullTotal = 0;
        $scope.NewSalesContract.TotalQty = 0;
        jQuery.each($scope.NewSalesContract.ItemVarients, function (i, val) {
            $scope.NewSalesContract.SubTotal = parseFloat($scope.NewSalesContract.SubTotal) + parseFloat($scope.NewSalesContract.ItemVarients[i].TotalAmount);
            $scope.NewSalesContract.TotalQty = parseFloat($scope.NewSalesContract.TotalQty) + parseFloat($scope.NewSalesContract.ItemVarients[i].Qty);
        });

        $scope.NewSalesContract.FullTotal = parseFloat($scope.NewSalesContract.SubTotal) + parseFloat($scope.NewSalesContract.ShippingCost);
        $scope.NewSalesContract.Total = $scope.NewSalesContract.FullTotal;

        var TotalPer = parseFloat(parseFloat($scope.NewSalesContract.Total) * parseFloat($scope.NewSalesContract.Deposite) / 100)
        $scope.NewSalesContract.Total = parseFloat($scope.NewSalesContract.Total) - TotalPer;
        $scope.NewSalesContract.Total = parseFloat($scope.NewSalesContract.Total) - parseFloat($scope.NewSalesContract.BBShippment);

        $scope.NewSalesContract.PayInWords = withDecimal(parseFloat($scope.NewSalesContract.FullTotal));
    }

    $scope.UpdateAmount = function (Index) {
        debugger
        $scope.NewSalesContract.ItemVarients[Index].TotalAmount = $scope.NewSalesContract.ItemVarients[Index].Qty * $scope.NewSalesContract.ItemVarients[Index].Price;
        ItemsTotalQtyAmount();

    }

    $scope.UpdateQtyAmount = function () {
        ItemsTotalQtyAmount();
    }

    function withDecimal(n) {
        var nums = n.toString().split('.')
        var whole = convertNumberToWords(nums[0])
        if (nums.length == 2) {
            var fraction = convertNumberToWords(nums[1])
            return whole + 'and ' + fraction;
        } else {
            return whole;
        }
    }

    $scope.remove = function (index) {
        $scope.NewSalesContract.ItemVarients.splice(index, 1);
    }

    $scope.SaveSalesContract = function () {
        debugger;

        if ($scope.NewSalesContract.CustomerID == undefined || $scope.NewSalesContract.CustomerID < 1) {
            $("#NewSalesContractCustomerID").css("border-color", "red");
            return;
        }
        else {
            $("#NewSalesContractCustomerID").css("border-color", "#d2d6de");
        }

        if ($scope.NewSalesContract.ShippingName == undefined || $scope.NewSalesContract.ShippingName < 2) {
            $("#NewSalesContractShippingName").css("border-color", "red");
            return;
        }
        else {
            $("#NewSalesContractShippingName").css("border-color", "#d2d6de");
        }

        if ($scope.NewSalesContract.ShippingAddress == undefined || $scope.NewSalesContract.ShippingAddress < 5) {
            $("#NewSalesContractShippingAddress").css("border-color", "red");
            return;
        }
        else {
            $("#NewSalesContractShippingAddress").css("border-color", "#d2d6de");
        }

        if ($scope.NewSalesContract.ItemVarients == undefined || $scope.NewSalesContract.ItemVarients.length < 1) {
            $('#alertMessage').html("Please Select Items!!!");
            $('#alertPopup').modal();
            return;
        }

        $scope.NewSalesContract.SalesContractDetails = $scope.NewSalesContract.ItemVarients;
        $http.post("/api/SalesContract/CreateSalesContract", $scope.NewSalesContract, config).success(function (data, status, headers, config) {
            debugger;
            if (data.ResponseCode == 200 && data.ResponseGenID != null && data.ResponseGenID != 0) {
                $('#alertMessage').html(data.ResponseMessage);
                $('#alertPopup').modal();

                setTimeout(function () {
                    $('#alertPopup').modal('hide');
                }, 1500);

                GetSalesContract();
                $scope.AddSales = !$scope.AddSales;
                $scope.SalesGrid = !$scope.SalesGrid;
                $scope.PrintSales = !$scope.PrintSales;
                $scope.PrintSalesshow = true;
                //$scope.ClearSales();
            }
            else {
                $('#alertMessage').html(data.ResponseMessage);
                $('#alertPopup').modal();
            }

        });
    }

    $scope.InvoiceSales = function () {
        debugger;
        //$scope.PrintSalesshow = false;
        //printContent("SalesInvoice");
        PrintSalesInvoice();
    }

    function PrintSalesInvoice() {
        html2canvas(document.getElementById('SalesInvoice'), {
            onrendered: function (canvas) {
                debugger;
                var data = canvas.toDataURL();
                var docDefinition = {
                    content: [{
                        image: data,
                        fit: [510, 761],
                    }]
                };
                pdfMake.createPdf(docDefinition).download("SalesInvoice.pdf");
            }
        });
    }

    $scope.DownloadSalesInvoice = function (SalID) {
        debugger;
        $scope.filteredTicket = $filter('filter')($scope.Sales, { IDNUMBER: SalID }, true);
        $scope.NewSalesContract = $scope.filteredTicket[0];
        $scope.NewSalesContract.IDNUMBER = $scope.filteredTicket[0].IDNUMBER;
        $scope.CustomerChange();

        $scope.NewSalesContract.ItemVarients = $scope.NewSalesContract.SalesContractDetails;

        $scope.NewSalesContract.FullTotal = parseFloat($scope.NewSalesContract.SubTotal) + parseFloat($scope.NewSalesContract.ShippingCost);
        $scope.NewSalesContract.Total = $scope.NewSalesContract.FullTotal;

        PrintSalesInvoice();
    };

    $scope.SalesInvoicePreview = function (SalID) {
        debugger;
        //$scope.AddSales = !$scope.AddSales;
        $scope.SalesGrid = !$scope.SalesGrid;
        $scope.PrintSales = !$scope.PrintSales;
        $scope.Errormessage = '';
        $scope.filteredTicket = $filter('filter')($scope.Sales, { IDNUMBER: SalID }, true);
        $scope.NewSalesContract = $scope.filteredTicket[0];
        $scope.NewSalesContract.IDNUMBER = $scope.filteredTicket[0].IDNUMBER;
        $scope.CustomerChange();

        $scope.NewSalesContract.ItemVarients = $scope.NewSalesContract.SalesContractDetails;

        $scope.NewSalesContract.FullTotal = parseFloat($scope.NewSalesContract.SubTotal) + parseFloat($scope.NewSalesContract.ShippingCost);
        $scope.NewSalesContract.Total = $scope.NewSalesContract.FullTotal;
    }

    $scope.CloseSalesPreview = function () {
        $scope.AddSales = false;
        $scope.SalesGrid = true;
        $scope.PrintSales = false;
    }

    $scope.CloseAddSales = function () {
        $scope.AddSales = !$scope.AddSales;
        $scope.SalesGrid = !$scope.SalesGrid;
        $scope.PrintSales = false;
    }

    $scope.ClearSales = function () {
        debugger;
        $scope.SalesPopupHeading = 'Add New Sales';
        $scope.SalesPopupBtn = 'Save Sales';
        $scope.AddSales = !$scope.AddSales;
        $scope.SalesGrid = !$scope.SalesGrid;
        $scope.PrintSales = false;
        $scope.Errormessage = '';
        $scope.NewSalesContract =
        {
            IDNUMBER: 0,
            CompanyID: 1,
            SONo: 0,
            SODate: SODate1,
            CustomerID: '',
            ShippingName: '',
            ShippingAddress: '',
            ShippingCost: '',
            PaymentType: 1,
            TotalQty: '',
            SubTotal: '',
            Currency: '',
            Deposite: '',
            BBShippment: '',
            Incoterms: '',
            IsActive: 1,
            IsSuperUser: 0,

            Customer: [],
            SalesContractDetails: [],
            ItemVarients: []
        }

        $scope.NewSalesContract.SubTotal = 0;
        $scope.NewSalesContract.Total = 0;
        $scope.NewSalesContract.FullTotal = 0;
        $scope.NewSalesContract.ShippingCost = 0;
        $scope.NewSalesContract.Deposite = 0;
        $scope.NewSalesContract.BBShippment = 0;
        $scope.NewSalesContract.TotalQty = 0;
        GetLastSalesID;
    }

}]);

CustomApp.controller('SalesController', ['$scope', '$http', '$filter', '$window', function ($scope, $http, $filter, $window) {
    $scope.message = 'Contact us! JK. This is just a demo.';
    $scope.Errormessage = '';

    $scope.AddSales = false;
    $scope.SalesGrid = true;
    $scope.PrintSales = false;
    $scope.PrintSalesshow = false;

    var config = {
        headers: {
            'Accept': 'application/json', 'Content-Type': 'application/json; charset=utf-8'
        }
    }

    $scope.SortSales = function (keyname) {
        $scope.sortKey = keyname;   //set the sortKey to the param passed
        $scope.reverse = !$scope.reverse; //if true make it false and vice versa
    }

    function GetLastSalesID() {
        $http.get("/api/Sales/GetLastSalesID").then(function (response) {
            debugger;
            var LastSalesID = response.data;
            LastSalesID = LastSalesID.replace(/[""]+/g, "");
            $scope.LastSalesID = LastSalesID;
            $scope.NewSales.SONo = 'CERPSO' + LastSalesID;
        });
    }

    var date = new Date();
    var SODate1 = date.getFullYear() + '-' + (date.getMonth() + 1) + '-' + date.getDate();


    $scope.NewSales =
    {
        IDNUMBER: 0,
        CompanyID: 1,
        SONo: '',
        SODate: SODate1,
        SupplierID: '',
        ShippingName: '',
        ShippingAddress: '',
        ShippingCost: '',
        PaymentType: 1,
        TotalQty: '',
        SubTotal: '',
        Currency: '',
        Deposite: '',
        BBShippment: '',
        Incoterms: '',
        IsActive: 1,
        IsSuperUser: 0,

        Customer: [],
        SalesDetails: [],
        ItemVarients: []
    };

    GetLastSalesID();

    $scope.NewItemVarient = [];

    $scope.NewSales.SubTotal = 0;
    $scope.NewSales.Total = 0;
    $scope.NewSales.FullTotal = 0;
    $scope.NewSales.ShippingCost = 0;
    $scope.NewSales.Deposite = 0;
    $scope.NewSales.BBShippment = 0;
    $scope.NewSales.TotalQty = 0;

    function GetSales() {
        $http.get("/api/Sales/GetSales").then(function (response) {
            debugger;
            $scope.Sales = response.data;
            $scope.SalesitemsPerPage = 10;
        });
    }

    function GetCustomers() {
        $http.get("/api/Customer/GetCustomers").then(function (response) {
            debugger;
            $scope.Customers = response.data;
        });
    }

    function GetItemVarients() {
        $http.get("/api/ItemVarient/GetItemVarients").then(function (response) {
            debugger;
            $scope.ItemVarients = response.data;
        });
    }

    GetCustomers();
    GetItemVarients();
    GetSales();

    $scope.CustomerChange = function () {
        debugger;
        var CustID = $scope.NewSales.CustomerID;
        $scope.filteredCustomers = $filter('filter')($scope.Customers, { IDNUMBER: CustID }, true);
        $scope.NewSales.Customer = $scope.filteredCustomers[0];
        $scope.NewSales.ShippingAddress = $scope.NewSales.Customer.ShippingAddress;

    }

    $scope.AddItemVarient = function () {
        debugger;

        if ($scope.NewItemVarient.ItemVarientID1 == undefined || $scope.NewItemVarient.ItemVarientID1 < 1) {
            $("#NewItemVarientID").css("border-color", "red");
            return;
        }
        else {
            $("#NewItemVarientID").css("border-color", "#d2d6de");
        }

        if ($scope.NewItemVarient.Qty1 == undefined || $scope.NewItemVarient.Qty1.length < 1) {
            $("#NewItemVarientQty").css("border-color", "red");
            return;
        }
        else {
            $("#NewItemVarientQty").css("border-color", "#d2d6de");
        }

        if ($scope.NewItemVarient.Price1 == undefined || $scope.NewItemVarient.Price1.length < 1) {
            $("#NewItemVarientPrice").css("border-color", "red");
            return;
        }
        else {
            $("#NewItemVarientPrice").css("border-color", "#d2d6de");
        }

        var ItemVarientID = $scope.NewItemVarient.ItemVarientID1;
        var Qty = $scope.NewItemVarient.Qty1;
        var Price = $scope.NewItemVarient.Price1;
        $scope.filteredItemVarients = $filter('filter')($scope.ItemVarients, { IDNUMBER: ItemVarientID }, true);
        $scope.NewItemVarient = $scope.filteredItemVarients[0];
        $scope.NewItemVarient.Qty = Qty;
        $scope.NewItemVarient.Price = Price;
        $scope.NewItemVarient.TotalAmount = Qty * Price;
        $scope.NewItemVarient.ItemVarientID = ItemVarientID;
        $scope.NewSales.ItemVarients.push($scope.NewItemVarient);
        ItemsTotalQtyAmount();
    }
    function ItemsTotalQtyAmount() {

        debugger;
        $scope.NewSales.SubTotal = 0;
        $scope.NewSales.Total = 0;
        $scope.NewSales.FullTotal = 0;
        $scope.NewSales.TotalQty = 0;
        jQuery.each($scope.NewSales.ItemVarients, function (i, val) {
            $scope.NewSales.SubTotal = parseFloat($scope.NewSales.SubTotal) + parseFloat($scope.NewSales.ItemVarients[i].TotalAmount);
            $scope.NewSales.TotalQty = parseFloat($scope.NewSales.TotalQty) + parseFloat($scope.NewSales.ItemVarients[i].Qty);
        });

        $scope.NewSales.FullTotal = parseFloat($scope.NewSales.SubTotal) + parseFloat($scope.NewSales.ShippingCost);
        $scope.NewSales.Total = $scope.NewSales.FullTotal;

        var TotalPer = parseFloat(parseFloat($scope.NewSales.Total) * parseFloat($scope.NewSales.Deposite) / 100)
        $scope.NewSales.Total = parseFloat($scope.NewSales.Total) - TotalPer;
        $scope.NewSales.Total = parseFloat($scope.NewSales.Total) - parseFloat($scope.NewSales.BBShippment);

        $scope.NewSales.PayInWords = withDecimal(parseFloat($scope.NewSales.FullTotal));
    }

    $scope.UpdateAmount = function (Index) {
        debugger
        $scope.NewSales.ItemVarients[Index].TotalAmount = $scope.NewSales.ItemVarients[Index].Qty * $scope.NewSales.ItemVarients[Index].Price;
        ItemsTotalQtyAmount();

    }

    $scope.UpdateQtyAmount = function () {
        ItemsTotalQtyAmount();
    }

    function withDecimal(n) {
        var nums = n.toString().split('.')
        var whole = convertNumberToWords(nums[0])
        if (nums.length == 2) {
            var fraction = convertNumberToWords(nums[1])
            return whole + 'and ' + fraction;
        } else {
            return whole;
        }
    }

    $scope.remove = function (index) {
        $scope.NewSales.ItemVarients.splice(index, 1);
    }

    $scope.SaveSales = function () {
        debugger;

        if ($scope.NewSales.CustomerID == undefined || $scope.NewSales.CustomerID < 1) {
            $("#NewSalesCustomerID").css("border-color", "red");
            return;
        }
        else {
            $("#NewSalesCustomerID").css("border-color", "#d2d6de");
        }

        if ($scope.NewSales.ShippingName == undefined || $scope.NewSales.ShippingName < 2) {
            $("#NewSalesShippingName").css("border-color", "red");
            return;
        }
        else {
            $("#NewSalesShippingName").css("border-color", "#d2d6de");
        }

        if ($scope.NewSales.ShippingAddress == undefined || $scope.NewSales.ShippingAddress < 5) {
            $("#NewSalesShippingAddress").css("border-color", "red");
            return;
        }
        else {
            $("#NewSalesShippingAddress").css("border-color", "#d2d6de");
        }

        if ($scope.NewSales.ItemVarients == undefined || $scope.NewSales.ItemVarients.length < 1) {
            $('#alertMessage').html("Please Select Items!!!");
            $('#alertPopup').modal();
            return;
        }

        $scope.NewSales.SalesDetails = $scope.NewSales.ItemVarients;
        $http.post("/api/Sales/CreateSales", $scope.NewSales, config).success(function (data, status, headers, config) {
            debugger;
            if (data.ResponseCode == 200 && data.ResponseGenID != null && data.ResponseGenID != 0) {
                $('#alertMessage').html(data.ResponseMessage);
                $('#alertPopup').modal();

                setTimeout(function () {
                    $('#alertPopup').modal('hide');
                }, 1500);

                GetSales();
                $scope.AddSales = !$scope.AddSales;
                $scope.SalesGrid = !$scope.SalesGrid;
                $scope.PrintSales = !$scope.PrintSales;
                $scope.PrintSalesshow = true;
                //$scope.ClearSales();
            }
            else {
                $('#alertMessage').html(data.ResponseMessage);
                $('#alertPopup').modal();
            }

        });
    }

    $scope.InvoiceSales = function () {
        debugger;
        //$scope.PrintSalesshow = false;
        //printContent("SalesInvoice");
        PrintSalesInvoice();
    }

    function PrintSalesInvoice() {
        html2canvas(document.getElementById('SalesInvoice'), {
            onrendered: function (canvas) {
                debugger;
                var data = canvas.toDataURL();
                var docDefinition = {
                    content: [{
                        image: data,
                        fit: [510, 761],
                    }]
                };
                pdfMake.createPdf(docDefinition).download("SalesInvoice.pdf");
            }
        });
    }

    $scope.DownloadSalesInvoice = function (SalID) {
        debugger;
        $scope.filteredTicket = $filter('filter')($scope.Sales, { IDNUMBER: SalID }, true);
        $scope.NewSales = $scope.filteredTicket[0];
        $scope.NewSales.IDNUMBER = $scope.filteredTicket[0].IDNUMBER;
        $scope.CustomerChange();

        $scope.NewSales.ItemVarients = $scope.NewSales.SalesDetails;

        $scope.NewSales.FullTotal = parseFloat($scope.NewSales.SubTotal) + parseFloat($scope.NewSales.ShippingCost);
        $scope.NewSales.Total = $scope.NewSales.FullTotal;

        PrintSalesInvoice();
    };

    $scope.SalesInvoicePreview = function (SalID) {
        debugger;
        //$scope.AddSales = !$scope.AddSales;
        $scope.SalesGrid = !$scope.SalesGrid;
        $scope.PrintSales = !$scope.PrintSales;
        $scope.Errormessage = '';
        $scope.filteredTicket = $filter('filter')($scope.Sales, { IDNUMBER: SalID }, true);
        $scope.NewSales = $scope.filteredTicket[0];
        $scope.NewSales.IDNUMBER = $scope.filteredTicket[0].IDNUMBER;
        $scope.CustomerChange();

        $scope.NewSales.ItemVarients = $scope.NewSales.SalesDetails;

        $scope.NewSales.FullTotal = parseFloat($scope.NewSales.SubTotal) + parseFloat($scope.NewSales.ShippingCost);
        $scope.NewSales.Total = $scope.NewSales.FullTotal;
    }

    $scope.CloseSalesPreview = function () {
        $scope.AddSales = false;
        $scope.SalesGrid = true;
        $scope.PrintSales = false;
    }

    $scope.CloseAddSales = function () {
        $scope.AddSales = !$scope.AddSales;
        $scope.SalesGrid = !$scope.SalesGrid;
        $scope.PrintSales = false;
    }

    $scope.ClearSales = function () {
        $scope.SalesPopupHeading = 'Add New Sales';
        $scope.SalesPopupBtn = 'Save Sales';
        $scope.AddSales = !$scope.AddSales;
        $scope.SalesGrid = !$scope.SalesGrid;
        $scope.PrintSales = false;
        $scope.Errormessage = '';
        $scope.NewSales =
        {
            IDNUMBER: 0,
            CompanyID: 1,
            SONo: 0,
            SODate: SODate1,
            CustomerID: '',
            ShippingName: '',
            ShippingAddress: '',
            ShippingCost: '',
            PaymentType: 1,
            TotalQty: '',
            SubTotal: '',
            Currency: '',
            Deposite: '',
            BBShippment: '',
            Incoterms: '',
            IsActive: 1,
            IsSuperUser: 0,

            Customer: [],
            SalesDetails: [],
            ItemVarients: []
        }

        $scope.NewSales.SubTotal = 0;
        $scope.NewSales.Total = 0;
        $scope.NewSales.FullTotal = 0;
        $scope.NewSales.ShippingCost = 0;
        $scope.NewSales.Deposite = 0;
        $scope.NewSales.BBShippment = 0;
        $scope.NewSales.TotalQty = 0;
    }

}]);

CustomApp.controller('ReportController', ['$scope', '$http', '$filter', '$window', function ($scope, $http, $filter, $window) {
    
    $scope.Errormessage = '';

    var config = {
        headers: {
            'Accept': 'application/json', 'Content-Type': 'application/json; charset=utf-8'
        }
    }

    $scope.PurchaseData = [];
    $scope.SalesData = [];
    $scope.ItemWiseSales = [];
    $scope.ItemWisePurchase = [];

    $scope.ItemWisePurchaseItemID = 0;
    $scope.ItemWiseSalesItemID = 0;

    $scope.Report = {
        PurchaseFromDate: '2017-12-01',
        PurchaseToDate: '2018-01-01',
        SalesFromDate: '2017-12-01',
        SalesToDate: '2018-01-01'
    }

    $scope.changeDatePurchase = function () {
        debugger;
        $scope.Report.PurchaseFromDate = $("#datepickerPurchaseFromDate").val();
        $scope.Report.PurchaseToDate = $("#datepickerPurchaseToDate").val();

        var PurchaseFromDate = new Date($scope.Report.PurchaseFromDate);
        var PurchaseToDate = new Date($scope.Report.PurchaseToDate);

        var FromDate = new Date(PurchaseFromDate.getFullYear(), PurchaseFromDate.getMonth(), PurchaseFromDate.getDate());
        var ToDate = new Date(PurchaseToDate.getFullYear(), PurchaseToDate.getMonth(), PurchaseToDate.getDate());

        if ($scope.Purchases != null && $scope.Purchases.length > 0) {
            $scope.PurchaseData = [];
            for (var i = 0; parseInt(i) < $scope.Purchases.length; i++) {
                debugger;
                var PODate = new Date($scope.Purchases[i].PODate);
                var CompareDate = new Date(PODate.getFullYear(), PODate.getMonth(), PODate.getDate());
                if (CompareDate >= FromDate && CompareDate <= ToDate) {
                    $scope.PurchaseData.push($scope.Purchases[i]);
                }
            }
        }
    }

    $scope.changeDateSales = function () {
        debugger;
        $scope.Report.SalesFromDate = $("#datepickerSalesFromDate").val();
        $scope.Report.SalesToDate = $("#datepickerSalesToDate").val();

        var SalesFromDate = new Date($scope.Report.SalesFromDate);
        var SalesToDate = new Date($scope.Report.SalesToDate);

        var FromDate = new Date(SalesFromDate.getFullYear(), SalesFromDate.getMonth(), SalesFromDate.getDate());
        var ToDate = new Date(SalesToDate.getFullYear(), SalesToDate.getMonth(), SalesToDate.getDate());

        if ($scope.Sales != null && $scope.Sales.length > 0) {
            $scope.SalesData = [];
            for (var i = 0; parseInt(i) < $scope.Sales.length; i++) {
                debugger;
                var SODate = new Date($scope.Sales[i].SODate);
                var CompareDate = new Date(SODate.getFullYear(), SODate.getMonth(), SODate.getDate());
                if (CompareDate >= FromDate && CompareDate <= ToDate) {
                    $scope.SalesData.push($scope.Sales[i]);
                }
            }
        }
    }

    function GetUsers() {
        $http.get("/api/User/GetUsers").then(function (response) {
            debugger;
            $scope.Users = response.data;
            $scope.UseritemsPerPage = 10;
        });
    }

    function GetPurchases() {
        $http.get("/api/Purchase/GetPurchases").then(function (response) {
            debugger;
            $scope.Purchases = response.data;
            $scope.PurchaseitemsPerPage = 10;
            $scope.PurchaseData = $scope.Purchases;
            $scope.ItemWisePurchase = $scope.Purchases;
        });
    }

    function GetSales() {
        $http.get("/api/Sales/GetSales").then(function (response) {
            debugger;
            $scope.Sales = response.data;
            $scope.SalesitemsPerPage = 10;
            $scope.SalesData = $scope.Sales;
            $scope.ItemWiseSales = $scope.Sales;
        });
    }

    function GetProducts() {
        $http.get("/api/Product/GetProducts").then(function (response) {
            debugger;
            $scope.Products = response.data;
            $scope.ProductitemsPerPage = 10;
        });
    }

    GetUsers();
    GetProducts();
    GetPurchases();
    GetSales();

    $scope.SearchItemWisePurchase = function () {
        debugger;
        var ItmID = $scope.ItemWisePurchaseItemID;

        if ($scope.Purchases != null && $scope.Purchases.length > 0) {
            $scope.ItemWisePurchase = [];

            for (var i = 0; parseInt(i) < $scope.Purchases.length; i++) {
                debugger;
                if ($scope.Purchases[i].PurchaseDetails != null && $scope.Purchases[i].PurchaseDetails.length > 0) {

                    for (var j = 0; j < $scope.Purchases[i].PurchaseDetails.length; j++) {

                        if (parseInt($scope.Purchases[i].PurchaseDetails[j].ItemID) == parseInt(ItmID)) {
                            $scope.ItemWisePurchase.push($scope.Purchases[i]);
                        }

                    }
                }
            }
        }
    }

    $scope.SearchItemWiseSales = function () {
        debugger;
        var ItmID = $scope.ItemWiseSalesItemID;

        if ($scope.Sales != null && $scope.Sales.length > 0)
        {
            $scope.ItemWiseSales = [];

            for (var i = 0; parseInt(i) < $scope.Sales.length; i++) {
                debugger;
                if ($scope.Sales[i].SalesDetails != null && $scope.Sales[i].SalesDetails.length > 0) {

                    for (var j = 0; j < $scope.Sales[i].SalesDetails.length; j++) {

                        if (parseInt($scope.Sales[i].SalesDetails[j].ItemID) == parseInt(ItmID)) {
                            $scope.ItemWiseSales.push($scope.Sales[i]);
                            
                        }

                    }
                }
            }
        }
    }

}]);

//CustomApp.filter("myfilter", function ($filter) {
//    return function (items, from, to, dateField) {
//        debugger; 
//        startDate = moment(from);
//        endDate = moment(to);
//        return $filter('filter')(items, function (elem) {
//            debugger;
//            var date = moment(elem[dateField]);
//            return date >= startDate && date <= endDate;
//        });
//    };
//});
