// import { Injectable } from '@angular/core';
// import ODataContext from 'devextreme/data/odata/context';
// import { environment } from '@env/environment';
// import { OAuthService } from 'angular-oauth2-oidc';
// import { AuthService } from '@modules/auth/auth.service';

// @Injectable({
//     providedIn: 'root'
// })

// export class ODataService {
//     public oDataContext: ODataContext;
//     constructor(
//         private authService: AuthService,
//         private oauthService: OAuthService) {

//         this.oDataContext = new ODataContext({
//             url: environment.ApiUri + '/odata',
//             version: 4,
//             errorHandler(error) {
//                 // console.log('odata context error', error);
//                 if (error.httpStatus === 401) {
//                     authService.logout();
//                 }
//             },
//             beforeSend(options) {
//                 options.headers = {
//                     Authorization: 'Bearer ' + oauthService.getAccessToken()
//                 };
//             },
//             entities: {
//                 Nominations: {
//                     key: 'NominationId',
//                     keyType: 'String'
//                 },
//                 Nodes: {
//                     key: 'NodeID',
//                     keyType: 'Int32'
//                 },
//                 PublicNodes: {
//                     key: 'NodeID',
//                     keyType: 'Int32'
//                 },
//                 NominationForms: {
//                     key: 'FormId',
//                     keyType: 'Int32'
//                 },
//                 StatusTypes: {
//                     key: 'StatusTypeId',
//                     keyType: 'Int32'
//                 },
//                 Users: {
//                     key: 'UserId',
//                     keyType: 'String'
//                 },
//                 DistrictSettings: {
//                     key: 'DistrictNodeId',
//                     keyType: 'Int32'
//                 },
//                 Reviews: {
//                     key: 'ReviewId',
//                     keyType: 'Int32'
//                 },
//                 CommitteeMemberReviews: {
//                     key: 'ReviewId',
//                     keyType: 'Int32'
//                 },
//                 DistrictPublicCommentTemplates: {
//                     key: 'CommentTemplateId',
//                     keyType: 'Int32'
//                 }
//             }
//         });
//     }

//     get context(): any {
//         return this.oDataContext;
//     }
// }