import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { FormsModule } from '@angular/forms';
import { NgIf } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, NgIf],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  email = '';
  password = '';
  loginError = '';

  constructor(private apiService: ApiService, private router: Router) { }

  ngOnInit(): void {
  }

  onSubmit() {
    const loginData = {
      email: this.email,
      password: this.password
    };

    this.apiService.login(loginData).subscribe(
      response => {
        console.log('Login bem-sucedido:', response);
        this.loginError = '';
        this.router.navigate(['/profile']);
      },
      error => {
        console.error('Erro no login:', error);
        this.loginError = 'Credenciais inválidas. Por favor, tente novamente.';
      }
    );
  }
}
