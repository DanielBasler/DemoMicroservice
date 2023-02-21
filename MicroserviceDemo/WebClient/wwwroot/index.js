function request(url, method, data) {
    return $.ajax({
        cache: false,
        dataType: 'json',
        url: url,
        data: data ? JSON.stringify(data) : null,
        method: method,
        contentType: 'application/json'
    });
}

function IndexModel() {
    this.elements = ko.observableArray([]);
    this.elementSelection = ko.observableArray(null);
    this.logs = ko.observableArray([]);
    var _this = this;

    this.getelements = function () {
        request('/api/elements/get', 'GET')
            .done(function (elements) {
                _this.elements(elements);
                console.log("get elements: ", elements);
            }).fail(function (err) {
                console.log("get elements error: ", err);
            });
    };

    this.getelementSelection = function () {
        request('/api/selectedElements/get', 'GET')
            .done(function (abstractElements) {
                _this.elementSelection(abstractElements);
                console.log("get Element: ", abstractElements);
            }).fail(function (err) {
                console.log("get Element error: ", err);
            });
    };

    this.addelement = function (id, qty) {
        request(`/api/selectedElements/addelement/${id}/${qty}`, 'PUT')
            .done(function (abstractElements) {
                _this.elementSelection(abstractElements);
                console.log("add Element: ", abstractElements);
            }).fail(function (err) {
                console.log("add Element error: ", err);
            });
    };

    this.delelement = function (id) {
        request(`/api/selectedElements/deleteelement?elementId=${id}`, 'DELETE')
            .done(function (abstractElements) {
                _this.elementSelection(abstractElements);
                console.log("del Element: ", abstractElements);
            }).fail(function (err) {
                console.log("del Element error: ", err);
            });
    };    

    this.getelements();
    this.getelementSelection();
}