# AI Chat Application

Full-stack conversational AI application with Angular frontend, ASP.NET Core backend, and local Mistral LLM via Ollama.

---

## 🛠️ Tech Stack

**Frontend:** Angular | TypeScript  
**Backend:** ASP.NET Core Web API | C#   
**AI Model:** Mistral 7B Instruct (Q4_0) via Ollama  
**Architecture:** REST API | Clean Architecture | DTO Pattern

---

## 🎯 Key Features

- Real-time AI chat with context retention
- RESTful API with CORS-enabled communication
- Local LLM deployment (no external API costs)
- Configurable system prompts and generation parameters
- Clean separation of concerns with service layer pattern

---

## 🏗️ Architecture
```
Angular UI → ASP.NET Core API → Ollama Server → Mistral 7B Model
```

**Model Details:**
- **Name:** Mistral 7B Instruct
- **Quantization:** 4-bit (Q4_0)
- **Context Window:** 8,192 tokens
- **Inference:** Local via Ollama

---

## ⚙️ Setup
```bash
# 1. Install and run Ollama with Mistral
ollama pull mistral:7b-instruct-q4_0
ollama run mistral

# 2. Start backend
cd backend
dotnet run

# 3. Start frontend
cd frontend
npm install
ng serve
```

---

## 📊 Skills Demonstrated

- **Frontend Development:** Angular, TypeScript, Component Architecture
- **Backend Development:** ASP.NET Core, REST APIs, Clean Architecture
- **AI/ML Integration:** LLM deployment, Prompt engineering, Context management
- **Software Design:** DTOs, Service patterns, CORS configuration
- **DevOps:** Local AI infrastructure, API integration

---

## 🚀 Future Enhancements

- **RAG Implementation:** Vector database (Pinecone/Qdrant) + semantic search
- **Streaming Responses:** WebSocket/SSE for real-time token streaming
- **Authentication:** JWT-based user management
- **Advanced Features:** Multi-model support, conversation persistence, fine-tuning
- **Production Ready:** Docker containerization, CI/CD pipeline, monitoring

---

## 📂 Project Structure
```
├── Ollama.Mistral.Demo.UI/        # Angular SPA
├── Ollama.Mistral.Demo/           # ASP.NET Core Web API
└── README.md
```
