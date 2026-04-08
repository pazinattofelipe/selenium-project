# 🧩 Test Strategy — File Upload Feature

## 📌 Overview
This document defines the test strategy for validating the file upload functionality available at:  
https://the-internet.herokuapp.com/upload

The objective is to verify that users can upload files successfully and that the system handles both valid and invalid interactions correctly.

---

## 🎯 Testing Scope

### ✅ In Scope
- File selection via "Browse" button
- File upload via "Upload" button
- Drag and drop file behavior
- File replacement behavior
- Validation of success and error messages
- Single file upload behavior

### 🚫 Out of Scope
- File storage validation on backend
- Security testing (e.g., malware scanning)
- Performance/load testing
- Mobile testing

---

## 🧪 Types of Testing

### Functional Testing
- Validate file upload functionality
- Verify correct messages and file name display

### Negative Testing
- Upload without selecting file
- Drag & drop failure scenarios
- Multiple file selection behavior

### UI/UX Testing
- Visibility and usability of buttons
- Feedback messages clarity

### Compatibility Testing
- Browser compatibility (Chrome, Firefox, Edge)

### Exploratory Testing
- Investigate inconsistent behaviors (e.g., drag & drop issues)

---

## 🔑 Key Test Scenarios

### ✅ Happy Path
- Upload a file using "Browse" button → Success message displayed
- Uploaded file name is correctly shown

### ⚠️ Edge Cases & Negative Scenarios
- Upload without selecting file → Internal Server Error
- Selecting a second file replaces the first
- Drag & drop single file → Upload fails
- Drag & drop multiple files → Upload fails
- Attempt multiple file upload via input → Only last file is considered

---

## 📊 Test Data Strategy

### Valid Files
- `file_example.pdf`
- `file_example.jpg`
- `file_example.xls`

### Edge Case Files
- Large file (if applicable)
- File with special characters in name (`test_#@!.txt`)

### Invalid Scenarios
- No file selected
- Multiple files selected (drag & drop)

---

## ⚙️ Manual vs Automated Testing Approach

### Manual Testing
- Exploratory testing (drag & drop behavior)
- UI/UX validation
- Error message validation

### Automation Testing

#### Scope:
- Happy path upload
- Validation of success message
- Upload without file
- File replacement behavior

#### Tools:
- Selenium

#### Strategy:
- Focus on stable flows (avoid drag & drop automation due to flakiness)
- Validate UI messages and file name dynamically

---

## ✅ Quality / Release Readiness Criteria

Release is considered ready when:

- Core upload functionality works reliably
- Success message and file name are displayed correctly
- No critical or high severity defects remain
- Known issues (e.g., drag & drop failure) are documented
- Regression tests pass successfully

---

## ⚠️ Risks & Mitigation Strategies

### 1. Drag & Drop Feature Not Working
**Risk:** Feature appears available but fails on upload  
**Mitigation:**  
- Document as known defect  
- Validate expected vs actual behavior  

---

### 2. Poor Error Handling
**Risk:** Generic "Internal Server Error" provides poor UX  
**Mitigation:**  
- Validate and report lack of user-friendly messaging  

---

### 3. File Replacement Confusion
**Risk:** Users may not realize second file overwrites first  
**Mitigation:**  
- Validate UI feedback (if any)  
- Suggest improvement if unclear  

---

### 4. Browser Inconsistencies
**Risk:** Upload behavior differs across browsers  
**Mitigation:**  
- Cross-browser validation on key flows  

---

# 🧪 Test Cases

---

## ✅ TC-001 — Upload File via Browse Button

**Preconditions:**
- User is on upload page
- Valid file available (`file_example.pdf`)

**Steps:**
1. Click "Choose File" button
2. Select `file_example.pdf`
3. Click "Upload"

**Expected Results:**
- Success message displayed: "File Uploaded!"
- Uploaded file name is displayed correctly

---

## ❌ TC-002 — Upload Without Selecting File

**Preconditions:**
- User is on upload page

**Steps:**
1. Click "Upload" without selecting a file

**Expected Results:**
- Page displays "Internal Server Error"

---

## 🔁 TC-003 — File Replacement Behavior

**Preconditions:**
- User is on upload page
- Two files available (`file_example.pdf`, `file_example.xls`)

**Steps:**
1. Click "Choose File"
2. Select `file_example.pdf`
3. Click "Choose File" again
4. Select `file_example.xls`
5. Click "Upload"

**Expected Results:**
- Only `file_example.xls` is uploaded
- Success message displayed
- Uploaded file name shown as `file_example.xls`

---

## ❌ TC-004 — Drag & Drop Single File

**Preconditions:**
- User is on upload page
- Valid file available

**Steps:**
1. Drag a file into drag & drop area
2. Click "Upload"

**Expected Results:**
- Upload fails
- No success message displayed

---

## ❌ TC-005 — Drag & Drop Multiple Files

**Preconditions:**
- User is on upload page
- Multiple files available

**Steps:**
1. Drag multiple files into drag & drop area
2. Click "Upload"

**Expected Results:**
- Upload fails
- No success message displayed

---

## 🔍 TC-006 — Validate Uploaded File Name

**Preconditions:**
- User is on upload page
- Known file available (`file_example.pdf`)

**Steps:**
1. Upload `file_example.pdf`
2. Observe result page

**Expected Results:**
- File name displayed matches uploaded file exactly

---
