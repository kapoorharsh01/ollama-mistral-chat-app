import { NgFor, NgIf } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';

// Represents a single chat message
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

  // Sends the user message to backend and returns model response
  ask(message: string) {
    return this.http.post<{ response: string }>(this.url + 'ask', { message });
  }

  input = ''; // Input bound to textbox
  loading = false; // Controls "Thinking/Loading" UI state
  messages: Message[] = []; // Stores full chat history

  send() {
    if (!this.input.trim()) return; // Ignore empty input
    const userMsg = this.input;
    this.input = '';

    this.messages.push({ role: 'user', content: userMsg });
    this.loading = true;

    // Call backend API
    this.ask(userMsg).subscribe({
      next: (res) => {
        // console.log(res.response);

        this.loading = false;
        this.messages.push({ role: 'assistant', content: res.response }); // Add model response to chat
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
