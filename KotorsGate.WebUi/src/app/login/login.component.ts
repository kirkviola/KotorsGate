import { CommonModule } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { Router, RouterModule } from '@angular/router';
import { switchMap } from 'rxjs';
import { AuthenticationService, Login } from 'src/app/security/authentication.service';
import { SessionStorageService } from 'src/app/security/session-storage.service';
import { UserService } from '../users/user.service';
import { CurrentUserService } from '../utils/current-user.service';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  standalone: true,
  imports: [
    CommonModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatProgressSpinnerModule,
    FormsModule,
    RouterModule,
  ],
  styleUrl: './login.component.scss'
})
export class LoginComponent implements OnInit {

  #authService = inject(AuthenticationService);
  #sessionService = inject(SessionStorageService);
  #userService = inject(UserService);
  #currentuserService = inject(CurrentUserService);
  #router = inject(Router);

  loginInfo: Login = {username: '', password: ''};

  errorMessage: string = '';

  showSpinner: boolean = false;

  ngOnInit(): void {

  }

  login(): void {
    this.showSpinner = true;
    this.#authService.login(this.loginInfo)
      .pipe(switchMap(authentication => {

      // Clear out token before attempting to login, if necessary
      const token = this.#sessionService.get(AuthenticationService.bearerTokenKey);

      if (token != null) {
        this.#sessionService.remove(AuthenticationService.bearerTokenKey);
      }

        this.#sessionService.set(AuthenticationService.bearerTokenKey, authentication.token);

        return this.#userService.getCurrentUser(authentication.user.id)
      }))
      .subscribe({
        next: user => {
          this.#currentuserService.setCurrentUser(user);
          this.#router.navigate(['/home']);
          this.showSpinner = false;
        },
        error: err => {
          this.errorMessage = 'Login failed';
          console.error(err); // For now
          this.showSpinner = false;
        }
      });
  }
}
