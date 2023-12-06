import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCardModule } from '@angular/material/card';
import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { User, UserCreation, UserService } from '../users/user.service';

@Component({
  selector: 'create-account-card',
  templateUrl: './create-account-card.component.html',
  standalone: true,
  imports: [
    CommonModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    FormsModule,
  ],
  styleUrl: './create-account-card.component.scss'
})
export class CreateAccountCardComponent {

  #userService = inject(UserService);

  userCreation: UserCreation = { username: '', passwordInit: '', passwordVerified: ''};

  passwordErrorDisplay: boolean = false;

  resultMessage: string = '';

  validateAndSubmit(): void {
    if (this.userCreation.passwordInit !== this.userCreation.passwordVerified) {
      this.passwordErrorDisplay = true;
      return;
    }

    const user = { id: 0, username: this.userCreation.username, password: this.userCreation.passwordInit } satisfies User;

    this.#userService.registerNewUser(user)
      .subscribe({
        next: res => {
          this.resultMessage = `New user created successfully: ${res.username}`;
        },
        error: err => {
          this.resultMessage = `Problems creating new user: ${err}`;
        }
      })
  }

}
