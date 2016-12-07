'use strict';

var spoonbendrApp = angular.module('spoonbendrApp', ['ngResource', 'ngRoute'])
	.config(function ($routeProvider) {
	    $routeProvider
		.when('/list_users', {
		    templateUrl: '/AngularTemplates/User/_UserList.html',
		    controller: 'UserListController'
		})
		.when('/edit_user/:id', {
		    templateUrl: 'templates/user_form.html',
		    controller: 'UserEditController'
		})
		.when('/new_user', {
		    templateUrl: 'templates/user_form.html'
		})
		.otherwise({
		    templateUrl: '/AngularTemplates/User/index_page.html'
		});
	});





