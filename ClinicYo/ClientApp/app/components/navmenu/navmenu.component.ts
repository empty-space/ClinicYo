import { Component } from '@angular/core';
import { MembershipService } from '../../modules/auth-module/services/membership.service';

@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.css']
})
export class NavMenuComponent {
    constructor(private auth: MembershipService) { }

    private checkMenu(menuName: string): boolean {
        if (this.auth.user && this.auth.user.credentials
            && this.auth.user.credentials.menus) {
            return this.auth.user.credentials.menus.indexOf(menuName) > -1;
        }
        return false;
    }
}
