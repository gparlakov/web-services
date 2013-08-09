/// <reference path="class.js" />
/// <reference path="controller.js" />
/// <reference path="http-requester.js" />
/// <reference path="jquery-2.0.2.js" />
/// <reference path="persister.js" />

$(document).ready(function () {
    $("#artists-holder").kendoGrid({
        dataSource: {
            //type: "odata",
            transport: {
                read: "http://localhost:49308/api/artists",
                //destroy: {
                //    url:"http://localhost:49308/api/artists/" + item.id,
                //    type: "DELETE"
                //},                
            },
            schema: {
                model: {
                    fields: {
                        Name: { type: "string" }
                        //OrderID: { type: "number" },
                        //Freight: { type: "number" },
                        //ShipName: { type: "string" },
                        //OrderDate: { type: "date" },
                        //ShipCity: { type: "string" }
                    }
                }
            },
            pageSize: 20,
            serverPaging: true,
            serverFiltering: true,
            serverSorting: true
        },
        height: 430,
        filterable: true,
        sortable: true,
        pageable: true,
        columns: [{
            field: "Name"
        }, {
            command: [{
                name: "Get Details",
                click: function (e) {
                    //TODO get details command
                }
            } , {
                name: "edit",
                click: function (e) {
                    alert("edit clicked");
                }
            },
            "destroy",
            ],

            width: 350,
            title: "Commands"
        }],
        editable: "inline",
    });
});

//$(document).ready(function () {    
//    //var controller = controllers.get("http://localhost:49308/api/");

//    var grid = $("#artists-holder").kendoGrid({
//        //attributes: {
//        //    width: "300px"
//        //},
//        type:"odata",
//        transport: {
//            read: "http://localhost:49308/api/Artists",
//            //create: "",
//            update: "",
//            //destroy: "",
//        },
//        dataSource: {
//            //data: artists,
//            schema: {
//                id: "Id",
//                model: {
//                    fields: {
//                        Name: {type:"string"}
//                    }
//                }
//            }
//        },
//        columns: [{
//            field: "Name",
//            width: 150,
//            title: "Name",

        //}, 
//        ],
//        toolbar: {

//        },
//        editable: "inline",

//        pageable: {
//            pageSize: 10,
//            pageSizes: [5, 10, 20],
//            refresh: true,
//            messages: {
//                refresh: "Refresh the grid"
//            },
//            //info: true,
//            //buttons:5,
//            //prevNext: true,                            
//        },

//        resizable: true,
//    });

//});

//<script>
//        var serviceUrl = "http://localhost:49308/api/";

//var requester = httpRequester.getJSON(serviceUrl + "Artists", function (artists) {
            
//},
//function (error) {
//    console.log(error.message)
//});

//var requester = httpRequester.postJSON(serviceUrl + "Artists", {Name:"Papata"}, function (response) {
//    console.log(response);
//},
//function (error) {
//    console.log(error.message)
//});
//</script>

//$(document).ready(function () {
//    $("#grid").kendoGrid({
//        dataSource: {
//            type: "odata",
//            transport: {
//                read: "http://localhost:49308/api/api/Artists"
//            },
//            schema: {
//                id: "Id",
//                model: {                    
//                    fields: {
//                        Name: { type: "number" },                        
//                    }
//                }
//            },
//            pageSize: 20,
//            serverPaging: true,
//            serverFiltering: true,
//            serverSorting: true
//        },
//        height: 430,
//        filterable: true,
//        sortable: true,
//        pageable: true,
//        columns: [{
//            field: "Name",
//            title: "Name",
//            width:150
//        }]
//    });
//});