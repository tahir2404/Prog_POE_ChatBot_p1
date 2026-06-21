# Cybersecurity Awareness Chatbot – Final POE (Part 3)

## Overview

The Cybersecurity Awareness Chatbot is an educational desktop application developed in C# using Windows Presentation Foundation (WPF). The chatbot aims to promote cybersecurity awareness among South African citizens by providing interactive guidance on online safety topics.

The application combines conversational AI concepts with practical cybersecurity education through features such as personalised responses, sentiment detection, memory recall, task management, reminders, quizzes, activity logging, Natural Language Processing (NLP), and MySQL database integration.

The chatbot enables users to learn about cybersecurity threats while managing their own cybersecurity improvement tasks in a user-friendly graphical interface.

---

## Project Objectives

The objectives of this project are to:

* Educate users about common cybersecurity threats.
* Promote safe online behaviour and cybersecurity best practices.
* Demonstrate conversational AI concepts using C#.
* Implement Natural Language Processing (NLP) techniques.
* Store and manage user tasks using a MySQL database.
* Provide personalised and engaging user interactions.
* Showcase software engineering principles such as object-oriented programming, database integration, and version control.

---

## Features

### GUI Interface

* Built using WPF (Windows Presentation Foundation)
* Modern chat interface with left and right message bubbles
* Scrollable conversation area
* Custom colour scheme and responsive layout

### Voice Greeting

* Plays a WAV audio greeting when the application launches
* Welcomes users to the chatbot experience

### Keyword Recognition

The chatbot recognises cybersecurity-related keywords such as:

* Password safety
* Phishing
* Scam awareness
* Online privacy
* Malware
* Safe browsing
* Social engineering

### Random Responses

* Uses randomised responses for cybersecurity topics
* Prevents repetitive interactions
* Creates a more natural conversation flow

### Memory and Recall

* Remembers the user's favourite cybersecurity topic
* Uses stored information later in the conversation to personalise responses

### Sentiment Detection

The chatbot detects simple user emotions such as:

* Worried
* Frustrated
* Curious

The bot responds empathetically based on the detected sentiment.

### Conversation Flow

The chatbot supports follow-up interactions such as:

* "Tell me more"
* "Another tip"
* "Explain more"

The chatbot remembers the previous topic and continues the conversation naturally.

### Task Management

Users can create and manage cybersecurity-related tasks, including:

* Add tasks
* View tasks
* Complete tasks
* Delete tasks
* Set reminders for tasks
* Receive automatic reminder notifications

### Database Integration

The chatbot uses a MySQL database to store tasks persistently.

Features include:

* Automatic task storage
* Loading saved tasks when the application starts
* Updating task completion status
* Deleting tasks from the database
* Persistent reminder storage

### Natural Language Processing (NLP)

The chatbot simulates Natural Language Processing by recognising different user intents.

Supported intents include:

* Add task
* Show tasks
* Complete task
* Delete task
* Set reminder
* Start quiz
* View activity log

Example phrases:

* "Remind me to update my password"
* "Show my tasks"
* "Play game"
* "What have you done for me?"

### Cybersecurity Quiz

The chatbot includes an interactive cybersecurity quiz that:

* Presents one question at a time
* Provides immediate feedback
* Tracks user scores
* Displays final results
* Reinforces cybersecurity knowledge

### Activity Logging

The chatbot records important user actions, including:

* Task creation
* Task completion
* Task deletion
* Reminder creation
* Quiz activity

Users can review recent actions using the activity log feature.

### Error Handling

* Prevents empty user input
* Handles unknown topics gracefully
* Displays helpful fallback responses

---

## Technologies Used

* C#
* .NET
* Windows Presentation Foundation (WPF)
* MySQL Server
* MySQL Workbench
* MySql.Data NuGet Package
* Visual Studio 2022/2026
* Git
* GitHub
* GitHub Actions

---

## Project Structure

Key classes used in the application include:

* ChatBot.cs
* ResponseEngine.cs
* MainWindow.xaml
* MainWindow.xaml.cs
* UserMemory.cs
* SentimentDetector.cs
* NlpProcessor.cs
* TaskManager.cs
* CyberTask.cs
* DatabaseHelper.cs
* QuizManager.cs
* QuizQuestion.cs
* ActivityLog.cs
* AudioHelper.cs

---

## Database Setup

1. Install MySQL Server and MySQL Workbench.

2. Create a database named:

   `CybersecurityBotDB`

3. Execute the following SQL script:

```sql
CREATE DATABASE CybersecurityBotDB;

USE CybersecurityBotDB;

CREATE TABLE Tasks (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Title VARCHAR(255) NOT NULL,
    Description TEXT,
    ReminderDate DATETIME NULL,
    IsCompleted BOOLEAN DEFAULT FALSE
);
```

4. Update the connection string in `DatabaseHelper.cs` with your MySQL credentials.

---

## Installation Instructions

1. Clone the repository.
2. Open the solution in Visual Studio.
3. Install the required NuGet packages.
4. Configure the MySQL database.
5. Update the database connection string.
6. Ensure the `greeting.wav` file is located in the `Assets` folder.
7. Build and run the WPF project.

---

## Required NuGet Packages

* MySql.Data

---

## Example Commands

### General Cybersecurity Questions

* Tell me about phishing
* Give me a password tip
* I am worried about scams
* Tell me more
* Another tip
* Help

### Task Management

* Add task to enable two-factor authentication
* Show my tasks
* Complete task enable two-factor authentication
* Delete task enable two-factor authentication

### Reminders

* Set reminder for update my password on 2026-07-15

### Quiz

* Start quiz
* Play game

### Activity Log

* Show activity log
* What have you done for me?

---


## GitHub Releases

The project uses semantic versioning:

* v1.0.0 – Part 1 Complete
* v2.0.0 – Part 2 Complete
* v3.0.0 – Final POE Submission

---

## Author

**Student Number: ST10471483

**Module:** PROG6221

---

## Video Demonstration

YouTube Video Link:

[]
