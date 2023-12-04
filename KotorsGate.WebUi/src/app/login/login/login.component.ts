import { Component, OnInit, inject } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService, Login } from 'src/app/security/authentication.service';
import { SessionStorageService } from 'src/app/security/session-storage.service';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent implements OnInit {
  #authService = inject(AuthenticationService);
  #sessionService = inject(SessionStorageService);
  #router = inject(Router);

  errorMessage: string = '';

  ngOnInit(): void {
    // Clear out token before attempting to login, if necessary
    const token = this.#sessionService.get(AuthenticationService.bearerTokenKey);

    if (token != null) {
      this.#sessionService.remove(AuthenticationService.bearerTokenKey);
    }
  }

  login(login: Login): void {
    this.#authService.login(login)
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
