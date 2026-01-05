import { NgFor, NgIf } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';

interface Message {
  role: 'user' | 'assistant';
  content: string;
}

@Component({
  selector: 'app-chat',
  imports: [FormsModule, NgIf, NgFor],
  templateUrl: './chat.component.html',
  styleUrl: './chat.component.css',
})

export class ChatComponent {
  private http = inject(HttpClient);
  url = 'https://localhost:7289/api/Mistral/';

  ask(message: string) {
    return this.http.post<{response: string}>(this.url + 'ask', { message });
  }

  input = '';
  loading = false;
  messages: Message[] = [];

  
  send() {
    if(!this.input.trim()) return;
    const userMsg = this.input;
    this.input = "";

    this.messages.push({ role: 'user', content: userMsg });
    this.loading = true;

    this.ask(userMsg).subscribe({
      next: (res) => {
        // console.log(res.response);
        
        this.loading = false;
        this.messages.push({ role: 'assistant', content: res.response})
      },
      error: (err) => {
        // console.log(err);
        this.loading = false;
        this.messages.push({
          role: 'assistant',
          content: 'Something went wrong!',
        });
      },
    });
  }
}
