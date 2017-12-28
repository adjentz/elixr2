import { Component, OnInit } from '@angular/core';
import { UserSessionService } from '../../services/user-session.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.less']
})
export class LoginComponent implements OnInit {

  username = '';
  password = '';
  confirmPassword = '';
  email = '';
  signingUp = false;
  loading = false;
  error = '';

  constructor(private userSession:UserSessionService) { }

  ngOnInit() {
  }

  async go(): Promise<void> {
    let promise = this.signingUp ? this.signup() : this.login();
    if (promise == null) {
      return;
    }

    this.loading = true;
    try {
      await promise;
    }
    catch (err) {
      this.error = err;
    }
    finally {
      this.loading = false;
    }
  }

  private async signup(): Promise<void> {
    if (!(this.password && this.password.length > 5)) {
      this.error = 'Must have password';
    }
    if (this.confirmPassword !== this.password) {
      this.error = 'Passwords do not match';
      return null;
    }
  }
  private async login(): Promise<void> {
    if (!(this.password && this.password.length > 5)) {
      this.error = 'Must have password';
    }
    if (!(this.username && this.username.length > 5)) {
      this.error = 'Must have username';
    }
  }
}
