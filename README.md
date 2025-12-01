# ProjectC#
<img width="804" height="535" alt="Image" src="https://github.com/user-attachments/assets/4b0468a0-fc28-469e-9873-9804ac27d913" />

📊 Student Grade Analyzer: Applied Math C# Project

Project Overview

This project is a Console Application developed in C# that serves as a robust Student Grade Analyzer. It is designed to input a flexible number of student grades, calculate essential statistics, determine letter grades, and summarize the overall class performance.

This application was developed to demonstrate a strong command of fundamental programming concepts in a practical, math-related context, fulfilling the requirements for Object-Oriented Programming, data handling, and file I/O.

Core Functionality

The program provides the following features:

Flexible Grade Input: Allows the user to input multiple grades (0-100) for an arbitrary number of students.

Individual Analysis: For each student, it calculates the Average, Minimum, and Maximum grades.

Letter Grade Assignment: Assigns a letter grade (A, B, C, D, F) based on the calculated average using conditional logic.

Class Statistics: Computes class-wide metrics, including the Overall Class Average, Highest/Lowest Grade recorded, and a Letter Grade Distribution summary.

Data Export (File Handling): Exports a detailed, structured summary report to a text file (Class_Summary_Report.txt) for permanent record-keeping.

C# Concepts Demonstrated

This project is structured specifically to integrate all required programming concepts:

Concept

Implementation Details

Object-Oriented Programming (OOP)

Uses the Student class to encapsulate data (name, grades) and behavior (CalculateAverage, GetLetterGrade). The GradeAnalyzer class manages the collection of Student objects and overall application flow.

Arrays / Collections

Uses List<int> within the Student class to store grades for a student, and List<Student> in the main program to store the class roster. A Dictionary is used for letter grade frequency counting.

Loops

while loops are used for collecting an indefinite number of student names and grades, ensuring flexible data entry. foreach loops iterate through students and their grades for calculations and display.

Conditionals

if/else if/else logic is used extensively within the Student class (GetLetterGrade method) to assign letter grades and in the InputStudentData method for input validation and program flow control.

File Handling

The ExportSummaryToFile method uses System.IO.File.WriteAllText to persist the final report to a text file, demonstrating core file I/O capabilities.

Strings

String manipulation is used for input parsing (Trim(), Equals()), output formatting (using string interpolation and padding like {"Name",-20}), and creating the export report using StringBuilder.

Mathematical/Logic Relevance

The core function is quantitative analysis: calculating mean (average), determining min/max values, and applying a weighted criteria (grade scale) to categorize results.

How to Run

Compile: Compile the GradeAnalyzer.cs file using the C# compiler.

Execute: Run the generated executable file.

Input: Follow the on-screen prompts to enter student names, followed by their individual grades (enter 0 to stop inputting grades for that student).

View: The program will immediately display the individual reports and the class summary in the console.

Check Output: The final report will be saved to a file named Class_Summary_Report.txt in the same directory as the executable.
<img width="1158" height="899" alt="Image" src="https://github.com/user-attachments/assets/ba95fee0-99b5-47d6-abb7-b5fad892939c" />
