import { Routes } from '@angular/router';
import { Home } from '../features/home/home';
import { MemberList } from '../features/members/member-list/member-list';
import { MemberDetails } from '../features/members/member-details/member-details';
import { Lists } from '../features/lists/lists';
import { Messages } from '../features/messages/messages';
import { authGuard } from '../core/gaurds/auth-guard';

export const routes: Routes = [
    {
        path: '', component: Home
    },
    {
        path: '', 
        runGuardsAndResolvers: 'always',
        canActivate: [authGuard],
        children: [
            {
                 path: 'members', component: MemberList, canActivate: [authGuard]
            },
            {
                path: 'member/:id', component: MemberDetails
            },
            {
                path: 'lists', component: Lists
            },
            {
                path: 'messages', component: Messages
            },
        ]
    },
    {
        path: '**', component: Home
    }
];
