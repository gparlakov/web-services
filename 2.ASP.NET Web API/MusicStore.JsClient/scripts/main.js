/// <reference path="jquery.min.js" />
/// <reference path="kendo.web.min.js" />

$(document).ready(function () {
    var baseUrl = "http://localhost:49308/api/";

    $("#artists-holder").kendoGrid({
        dataSource: {
            //type: "odata",
            transport: {
                read: {
                    type:"GET",
                    url: baseUrl + "artists",
                },
                create: {
                    type: "POST",
                    url: baseUrl + "artists",
                },
                update: {
                    type: "PUT",
                    url: function (model) {
                        var url = baseUrl + "artists/" + model.Id;
                        return url;
                    },
                },
                destroy: {
                    type: "DELETE",
                    url: function (model) {
                        var url = baseUrl + "artists/" + model.Id;
                        return url;
                    },
                },
            },
            schema: {
                model: {
                    id: "Id",
                    fields: {
                        Id: { type: "number" },
                        Name: { type: "string" },                        
                        Country: { type: "string" },
                    }
                }
            },
            pageSize: 5,
            //serverPaging: true,
            //serverFiltering: true,
            //serverSorting: true
        },        
        //height: 430,
        //filterable: true,
        sortable: true,
        pageable: {
            buttons: 5,
            refresh: true
        },
        columns: [{
            field: "Name",
            width:200,
        } , {            
            field: "Country",
            width:150        
        }, {
            command: [
                {
                //    name: "Get Details",
                //    click: function (e) {
                //        //TODO get details command
                //    }
                //} , {
                name: "edit"
                }, {
                name: "destroy"
                }
            ],

            width: 350,
            title: "Commands"
        }],
        editable: "inline",
        toolbar: ["create", "save", "cancel"],
    });

    $("#songs-holder").kendoGrid({
        dataSource: {
            //type: "odata",
            transport: {
                read: {
                    type: "GET",
                    url: baseUrl + "songs",
                    contentType:"json"
                },
                create: {
                    type: "POST",
                    url: baseUrl + "songs",
                },
                update: {
                    type: "PUT",
                    url: function (model) {
                        var url = baseUrl + "songs/" + model.Id;
                        return url;
                    },
                },
                destroy: {
                    type: "DELETE",
                    url: function (model) {
                        var url = baseUrl + "songs/" + model.Id;
                        return url;
                    },
                },
            },
            schema: {
                model: {
                    id: "Id",
                    fields: {
                        Id: { type: "number" },
                        Title: { type: "string" },
                        Year: { type: "number", },
                    }
                }
            },
            pageSize: 5,
            //serverPaging: true,
            //serverFiltering: true,
            //serverSorting: true
        },
        //height: 430,
        //filterable: true,
        sortable: true,
        pageable: {
            buttons: 5,
            refresh: true
        },
        columns: [{
            field: "Title",
            width: 200,
        }, {
            field: "Year",
            width: 100,
        }, {
            command: [
                {
                    //    name: "Get Details",
                    //    click: function (e) {
                    //        //TODO get details command
                    //    }
                    //} , {
                    name: "edit"
                }, {
                    name: "destroy"
                }
            ],

            width: 350,
            title: "Commands"
        }],
        editable: "inline",
        toolbar: ["create", "save", "cancel"],
    });

    $("#albums-holder").kendoGrid({
        dataSource: {
            title:"test",
            //type: "odata",
            transport: {
                read: {
                    type: "GET",
                    url: baseUrl + "albums/",
                    contentType: "json"
                },
                create: {
                    type: "POST",
                    url: baseUrl + "albums/",
                },
                update: {
                    type: "PUT",
                    url: function (model) {
                        var url = baseUrl + "albums/" + model.Id;
                        return url;
                    },
                },
                destroy: {
                    type: "DELETE",
                    url: function (model) {
                        var url = baseUrl + "albums/" + model.Id;
                        return url;
                    },
                },
            },
            schema: {
                model: {
                    id: "Id",
                    fields: {
                        Id: { type: "number" },
                        Title: { type: "string" },                        
                    }
                }
            },
            pageSize: 5,
        },
        sortable: true,
        pageable: {
            buttons: 5,
            refresh: true
        },
        columns: [{
            field: "Title",
            width: 200,
        }, {
            command: ["edit", "destroy"],
            width: 350,
            title: "Commands"
        }],
        editable: "inline",
        toolbar: ["create", "save", "cancel"],
    });
});