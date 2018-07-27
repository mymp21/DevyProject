'use strict';
angular.module('admin.routes', [])
    .config(function ($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.when('/', '/admin/dashboard');
        $stateProvider
            .state('admin', {
                abstract: true,
                url: '/admin',
                templateUrl: '/apps/templates/base.html',
                controller: 'UserController'
            })
            .state('dashboard', {
                url: '/dashboard',
                parent: 'admin',
                templateUrl: '/apps/templates/admin/dashboard.html',
                controller: 'DashboardController'
            })

            .state('petugas', {
                url: '/petugas',
                parent: 'admin',
                templateUrl: '/apps/templates/admin/petugas.html',
                controller: 'PetugasController'
            })
            .state('pengaduan', {
                url: '/pengaduan',
                parent: 'admin',
                templateUrl: '/apps/templates/admin/pengaduan.html',
                controller: 'PengaduanController'
            })
            .state('pemasangan', {
                url: '/pemasangan',
                parent: 'admin',
                templateUrl: '/apps/templates/admin/pemasangan.html',
                controller: 'PemasanganController'
            })


    })
   ;