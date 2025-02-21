import React from 'react';
import { Link } from 'react-router-dom';

function HomePage() {
    return (
        <div className="min-h-screen bg-indigo-900 text-white flex flex-col items-center justify-center">
            <h1 className="text-4xl font-bold mb-4">Welcome to our project page!</h1>
            <h3 className="text-xl mb-8">Where do you want to go?</h3>
            <div className="flex space-x-4">
                <button className="bg-indigo-700 hover:bg-indigo-600 text-white font-semibold py-2 px-6 rounded-lg shadow-lg transition duration-300">
                    <Link to="/projects/create">Create Project</Link>
                </button>
                <button className="bg-indigo-700 hover:bg-indigo-600 text-white font-semibold py-2 px-6 rounded-lg shadow-lg transition duration-300">
                    <Link to="/projects">View Projects</Link>
                </button>
            </div>
        </div>
    );
}

export default HomePage;