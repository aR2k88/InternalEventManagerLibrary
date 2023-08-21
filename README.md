# EventManager Class Library

The **EventManager** class library provides a simple and efficient way to implement the publish-subscribe (pub-sub) pattern in your applications. This pattern facilitates communication between different components of your system by allowing them to communicate without requiring direct dependencies on each other. This document serves as a guide to understand and use the features provided by the EventManager library.

## Table of Contents

- [Introduction](#introduction)
- [Getting Started](#getting-started)
- [Usage](#usage)
    - [Publishing Events](#publishing-events)
    - [Subscribing to Events](#subscribing-to-events)
    - [Unsubscribing from Events](#unsubscribing-from-events)
- [Best Practices](#best-practices)
- [Examples](#examples)
- [Contributing](#contributing)
- [License](#license)

## Introduction

The EventManager class library simplifies event-driven communication within your application. It utilizes the publish-subscribe pattern, enabling various components to interact with each other without direct coupling. By using this library, you can easily separate concerns and achieve better maintainability and scalability in your projects.

## Getting Started

To use the EventManager class library in your project, follow these steps:

1. **Installation**: Add a reference to the EventManager library in your project. You can do this by either including the compiled library or using a package manager compatible with your development environment.

2. **Initializing the EventManager**: Create an instance of the `EventManager` class to start using the pub-sub functionalities.

## Usage

### Publishing Events

To publish an event, call the `Publish<TEvent>(TEvent @event)` method on the `EventManager` instance. The event will then be delivered to all subscribed event consumers of the corresponding event type.

```csharp
// Create an instance of the EventManager
IEventManager eventManager = new EventManager();

//Dependency injection
services.AddSingleton<IEventManager, EventManager>();

// Publish an event
var eventData = new MyEvent(/* event data */);
eventManager.Publish(eventData);
```

### Subscribing to Events

To subscribe to events, implement the `IEventConsumer<TEvent>` interface in your event consumer class. Then, use the `Subscribe<TEvent>(IEventConsumer<TEvent> handler)` method to register the event consumer.

```csharp
// Define an event consumer
public class MyEventConsumer : IEventConsumer<MyEvent>
{
    public async Task Consume(MyEvent @event)
    {
        // Handle the event data
        await Task.Delay(100); // Simulate processing
    }
}

// Subscribe the event consumer
var eventConsumer = new MyEventConsumer();
eventManager.Subscribe(eventConsumer);
```

### Unsubscribing from Events

To unsubscribe from events, use the `Unsubscribe<TEvent>(IEventConsumer<TEvent> handler)` method.

```csharp
// Unsubscribe the event consumer
eventManager.Unsubscribe(eventConsumer);
```

## Best Practices

- Keep event consumers lightweight and responsive. Avoid performing heavy operations within the `Consume` method to prevent blocking the event processing pipeline.

- Use appropriate error handling within event consumers to ensure robustness.

- Ensure proper cleanup by unsubscribing from events when an event consumer is no longer needed.

---

Happy coding!
