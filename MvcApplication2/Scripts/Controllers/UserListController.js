'use strict';


spoonbendrApp.controller('UserListController', 
	function UserListController($scope, userService){
		userService.getAllUsers()
		.then(function(response) {
			$scope.users = response.data;
		});
	});

