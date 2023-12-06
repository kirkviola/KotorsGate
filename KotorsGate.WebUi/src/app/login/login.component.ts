import { CommonModule } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { Router, RouterModule } from '@angular/router';
import { AuthenticationService, Login } from 'src/app/security/authentication.service';
import { SessionStorageService } from 'src/app/security/session-storage.service';

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
    FormsModule,
    RouterModule,
  ],
  styleUrl: './login.component.scss'
})
export class LoginComponent implements OnInit {
  #authService = inject(AuthenticationService);
  #sessionService = inject(SessionStorageService);
  #router = inject(Router);

  loginInfo: Login = {username: '', password: ''};

  errorMessage: string = '';

  ngOnInit(): void {
    // Clear out token before attempting to login, if necessary
    const token = this.#sessionService.get(AuthenticationService.bearerTokenKey);

    if (token != null) {
      this.#sessionService.remove(AuthenticationService.bearerTokenKey);
    }
  }

  login(): void {
    this.#authService.login(this.loginInfo)
      .subscribe({
        next: authentication => {
          this.#sessionService.set(AuthenticationService.bearerTokenKey, authentication);
          this.#router.navigate(['/home']);
        },
        error: err => {
          this.errorMessage = 'Login failed';
          console.error(err); // For now
        }
      });
  }
}