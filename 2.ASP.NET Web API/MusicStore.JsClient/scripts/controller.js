/// <reference path="class.js" />
/// <reference path="persister.js" />
/// <reference path="jquery.min.js" />
/// <reference path="kendo.web.js" />
/// <reference path="ui.js" />

var controllers = (function () {
	var rootUrl = "http://localhost:40643/api/";
	var Controller = Class.create({

        // for VS Intellisence TODO - remove
	    persister: {},
	    artistsController: {},

	    init: function (url) {
	        this.persister = persisters.get(url);
	        this.artistsController = artistsController.get(this.persister);

	        this.initEvents();
	    },

	    initEvents: function () {
	        //this.artistsController.init();
	    },
	});

	return {
		get: function (url) {
			return new Controller(url);
		}
	}
}());


var artistsController = (function () {
    var ArtistsController = Class.create({
        init: function (persister) {
            this.dataPersister = persister;

            this.initEvents();
        },
        initEvents: function(){
            var self = this;

            $("#get-all-artists").click(function () {
                self.dataPersister.artists.getAll(function (artists) {
                    //var artistsString = "";

                    //for (var i = 0; i < artists.length; i++) {
                    //    artistsString += "<span data-id-" + artists[i].Id + ">" + artists[i].Name + "| </span>";
                    //}

                    $("#artists-holder").kendoGrid({
                        //attributes: {
                        //    width: "300px"
                        //},
                        transport: {
                            read: {
                                url: "http://localhost:40643/api/Artists",
                                type: "json"
                            },
                            create: "",
                            update: "",
                            destroy: "",
                        },
                        dataSource: {
                            data: artists,
                            schema: {
                                id:"Id",
                            }
                        },
                        columns: [{
                            field: "Name",
                            width: 150,
                            title: "Name",
                            
                            }, {
                            command: [{
                                name: "Get Details",
                                click: function (e) {
                                        //TODO get details command
                                    }
                                },
                                "destroy",
                                "edit"
                            ],

                                width:150
                            }
                        ],

                        editable: "inline",

                        pageable: {
                            pageSize: 10,
                            pageSizes:[5,10,20],                            
                            refresh: true,
                            messages: {
                                refresh: "Refresh the grid"
                            },
                            //info: true,
                            //buttons:5,
                            //prevNext: true,                            
                        },

                        resizable: true,                       
                    });
                },
                function (error) {
                    self.errorFunction(error, "#artists-holder");
                });
            });
        },
        errorFunction: function (error, holder) {
            var message = $("<span>" + error.message + "</span>");

            $(holder).add(message);
        }
    });

    return {
        get: function(persister){
            return new ArtistsController(persister);
        }
    }
})();
