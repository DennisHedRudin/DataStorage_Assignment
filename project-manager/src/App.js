import React from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import ProjectListPage from "./components/ProjectListPage";
import CreateProjectPage from "./components/CreateProjectPage";
import EditProjectPage from "./components/EditProjectPage";
import ProjectList from "./components/ProjectList";

function App() {
  return (
    <Router>
      <div>        
        <Routes>          
          <Route path="/project-list" element={<ProjectList />} /> {/* Justera för korrekt path */}
          <Route path="/projects" element={<ProjectListPage />} />
          <Route path="/projects/create" element={<CreateProjectPage />} />
          <Route path="/projects/edit/:id" element={<EditProjectPage />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;