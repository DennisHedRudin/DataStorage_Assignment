import React, { useState } from "react";
import { createProject } from "../services/projectService";
import { useNavigate } from "react-router-dom"; // Importera useNavigate istället för useHistory

const CreateProjectPage = () => {
  const [title, setTitle] = useState("");
  const [startDate, setStartDate] = useState("");
  const [endDate, setEndDate] = useState("");
  const navigate = useNavigate(); // Använd useNavigate istället för useHistory

  const handleCreate = async (e) => {
    e.preventDefault();
    const newProject = {
      title,
      startDate,
      endDate,
    };

    try {
      await createProject(newProject);
      navigate("/projects"); // Använd navigate istället för history.push
    } catch (error) {
      console.error("Error creating project", error);
    }
  };

  return (
    <div>
      <h1>Create New Project</h1>
      <form onSubmit={handleCreate}>
        <label>
          Project Title:
          <input
            type="text"
            value={title}
            onChange={(e) => setTitle(e.target.value)}
            required
          />
        </label>
        <label>
          Start Date:
          <input
            type="date"
            value={startDate}
            onChange={(e) => setStartDate(e.target.value)}
            required
          />
        </label>
        <label>
          End Date:
          <input
            type="date"
            value={endDate}
            onChange={(e) => setEndDate(e.target.value)}
            required
          />
        </label>
        <button type="submit">Create Project</button>
      </form>
    </div>
  );
};

export default CreateProjectPage;