/// <reference path="http-requester.js" />
/// <reference path="class.js" />

var persisters = (function () {
	//var nickname = localStorage.getItem("nickname");
	//var sessionKey = localStorage.getItem("sessionKey");

	//function saveUserData(userData) {
	//	localStorage.setItem("nickname", userData.nickname);
	//	localStorage.setItem("sessionKey", userData.sessionKey);
	//	nickname = userData.nickname;
	//	sessionKey = userData.sessionKey;
	//}

	//function clearUserData() {
	//	localStorage.removeItem("nickname");
	//	localStorage.removeItem("sessionKey");
	//	nickname = "";
	//	sessionKey = "";
	//}

	var MainPersister = Class.create({
		init: function (rootUrl) {
			this.rootUrl = rootUrl;
			this.artists = new ArtistPersister(this.rootUrl);
			//this.game = new GamePersister(this.rootUrl);
		},
		//isUserLoggedIn: function () {
		//	var isLoggedIn = nickname != null && sessionKey != null;
		//	return isLoggedIn;
		//},
		//nickname: function () {
		//	return nickname;
		//}
	});

	var ArtistPersister = Class.create({
		init: function (rootUrl) {
			//...api/user/
			this.rootUrl = rootUrl + "Artists/";
		},

		getAll: function (success, error) {			
		    httpRequester.getJSON(this.rootUrl, success, error);
		},
		get: function (id, success, error) {
		    httpRequester.getJSON(this.rootUrl + "/" + id, success, error);
		},
	});

	//var GamePersister = Class.create({
	//	init: function (url) {
	//		this.rootUrl = url + "game/";
	//	},
	//	create: function (game, success, error) {
	//		var gameData = {
	//			title: game.title,
	//			number: game.number
	//		};
	//		if (game.password) {
	//			gameData.password = CryptoJS.SHA1(game.password).toString();
	//		}
	//		var url = this.rootUrl + "create/" + sessionKey;
	//		httpRequester.postJSON(url, gameData, success, error);
	//	},
	//	join: function (game, success, error) {
	//		var gameData = {
	//			gameId: game.gameId,
	//			number: game.number
	//		};
	//		if (game.password) {
	//			gameData.password = CryptoJS.SHA1(game.password).toString();
	//		}
	//		var url = this.rootUrl + "join/" + sessionKey;
	//		httpRequester.postJSON(url, gameData, success, error);
	//	},
	//	start: function () {

	//	},
	//	myActive: function (success, error) {
	//		var url = this.rootUrl + "my-active/" + sessionKey;
	//		httpRequester.getJSON(url, success, error);
	//	},
	//	open: function (success, error) {
	//		var url = this.rootUrl + "open/" + sessionKey;
	//		httpRequester.getJSON(url, success, error);
	//	},
	//	state: function (gameId, success, error) {
	//		var url = this.rootUrl + gameId + "/state/" + sessionKey;
	//		httpRequester.getJSON(url, success, error);
	//	}
	//});

	//var GuessPersister = Class.create({
	//	init: function () {

	//	},
	//	make: function () {

	//	}
	//});

	//var MessagesPersister = Class.create({
	//	init: function () {

	//	},
	//	unread: function () {

	//	},
	//	all: function () {

	//	}
	//});
    
	return {
		get: function (url) {
			return new MainPersister(url);
		}
	};
}());