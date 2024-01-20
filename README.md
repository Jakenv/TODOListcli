# TODO Console app
It's a simple app I made while learning C#

It's a simple todo list that you can fill up to 6 spots and remove entries from

Requires **dotNet 8.0 runtime**

### Known bugs
- If you fill the list and then remove first entry and try to add new one, program will put new entry on the last spot overwriting it. This is caused because of the method that is used to evaluate where to put new entry. I should add some kind of index checker or sorting method instead of the current loop
