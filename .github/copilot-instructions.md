# Copilot Instructions for ECommerceApp

This repository is a small ASP.NET Core minimal API project built to demonstrate classic GoF design patterns. The code is intentionally simple; focus is on understanding how the patterns are used rather than business logic.

## High‑level architecture 🏗️

* **Single project**: `ECommerceApp` is a web app targeting .NET 9.0. There are no separate class libraries or services.
* **Startup**: everything lives in `Program.cs`. Two endpoints are defined:
  * `GET /api/shop/products` returns a hard‑coded product catalog.
  * `POST /api/shop/checkout` runs through a sequence of design pattern snippets and returns a summary.
* **Patterns folder** (`Patterns/Creational`, `Patterns/Structural`, `Patterns/Behavioral`): contains small classes that implement each relevant GoF pattern.
  * Patterns are not wired into a framework; they are consumed manually in `Program.cs` to illustrate usage.
  * Examples include `OrderFacade`, `DiscountContext`, `PriorityShippingDecorator`, etc.

> ⚠️ There is no database, authentication, or real business logic. Treat this code as a learning scaffold.

## Key files & directories 📁

* `Program.cs` – entry point; easiest place to see how patterns are combined. Add new endpoints here if you want to experiment.
* `Patterns/*` – categories match GoF groups. Each file usually contains one interface/class pair.
* `wwwroot/index.html` – placeholder front‑end (static) if you launch the app in a browser.
* `ECommerceApp.csproj` – .NET Web SDK, includes `Swashbuckle.AspNetCore` for Swagger UI on `/swagger`.

## Common developer workflows ⚙️

* **Build & run** (CLI or VS):
  ```sh
  cd ECommerceApp
  dotnet build      # compile
  dotnet run        # launch local server (http://localhost:5000 by default)
  ```
  Swagger UI is available at `http://localhost:5000/swagger`.
* **Debugging**: open `.sln` in Visual Studio/VS Code, set breakpoints in `Program.cs` or any pattern class, then launch with the debugger. Minimal APIs and record types make stepping straightforward.
* **Static assets**: `app.UseDefaultFiles()` serves `wwwroot/index.html`; modify it if you want to test JS calls to the API.

## Project conventions & patterns 📌

* Namespaces mirror folder structure: `ECommerceApp.Patterns.Behavioral`, etc.
* No dependency injection container is used; objects are created inline in the example handlers.
* Record types (`CartRequest`, `CartItem`) are defined at the bottom of `Program.cs` for simple binding.
* Internationalised comments are in Russian (e.g. `// 1. Каталог товаров`) — keep that style when adding new comments to stay consistent.

## External integrations & dependencies 🔗

* Only external package is **Swashbuckle** for Swagger. No database, cloud services or third‑party APIs.
* Product catalog and checkout are purely in‑memory; additional services should be stubbed/mocked similarly.

## Tips for AI coding agents 🤖

1. **Understand the learning intent**: every change should preserve the pattern demonstrations. Don’t replace `new OrderFacade()` with a real service unless you also explain the pattern.
2. **Add examples**: if you introduce a new pattern, update both the appropriate folder under `Patterns/` *and* `Program.cs` sample handler. Show request/response shapes if relevant.
3. **Preserve minimal API style**: use `app.MapGet`/`MapPost` with lambdas and simple record binding. Avoid adding controllers or excessive abstraction unless explicitly requested.
4. **Keep builds simple**: only use `dotnet` commands shown above; avoid adding complex build scripts or CI tasks.
5. **Language**: source comments use Russian; mimic this when editing. Response strings returned by endpoints are often simple JSON literals.

## Future changes guidance ✨

* If you add persistent storage, note that the current project has none — update the README or instructions accordingly.
* New architectural components (services, middleware) should be documented in this `.md` so an AI agent knows where to look.

---

> _Need more detail or see ambiguity?_ Ask for clarification or mention file names to inspect. 💬
