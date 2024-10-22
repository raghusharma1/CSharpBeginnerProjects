// ********RoostGPT********
/*
Test generated by RoostGPT for test sampleCSharpEnv using AI Type  and AI Model 

ROOST_METHOD_HASH=Run_a2e9436d0a
ROOST_METHOD_SIG_HASH=Run_9ce955ed80

   ########## Test-Scenarios ##########  

Based on the provided method and related code, here are several test scenarios for the `Run` method of the `DepthFirstSearch` class:

Scenario 1: Null Graph Input

Details:
  TestName: ThrowArgumentNullExceptionWhenGraphIsNull
  Description: Verify that the method throws an ArgumentNullException when a null graph is passed as an argument.
Execution:
  Arrange: Create a DepthFirstSearch instance.
  Act: Call the Run method with a null graph.
  Assert: Expect an ArgumentNullException to be thrown.
Validation:
  This test ensures that the method properly handles null input, preventing potential null reference exceptions later in the execution.

Scenario 2: Empty Graph

Details:
  TestName: RunSuccessfullyOnEmptyGraph
  Description: Ensure the method can handle an empty graph without errors.
Execution:
  Arrange: Create a DepthFirstSearch instance and an empty IGraph<DFSVertex>.
  Act: Call the Run method with the empty graph.
  Assert: Verify that the method completes without throwing any exceptions.
Validation:
  This test confirms that the method can handle edge cases like empty graphs without failing.

Scenario 3: Single Vertex Graph

Details:
  TestName: ProcessSingleVertexGraphCorrectly
  Description: Check if the method correctly processes a graph with only one vertex.
Execution:
  Arrange: Create a DepthFirstSearch instance and an IGraph<DFSVertex> with a single vertex.
  Act: Call the Run method with the single-vertex graph.
  Assert: Verify that the vertex's StartTime and EndTime are set and Processed is true.
Validation:
  This test ensures that the basic functionality works for the simplest possible graph.

Scenario 4: Connected Graph

Details:
  TestName: ProcessAllVerticesInConnectedGraph
  Description: Verify that all vertices in a connected graph are processed.
Execution:
  Arrange: Create a DepthFirstSearch instance and a connected IGraph<DFSVertex> with multiple vertices.
  Act: Call the Run method with the connected graph.
  Assert: Check that all vertices have been processed (Processed is true for all vertices).
Validation:
  This test confirms that the method correctly traverses all vertices in a connected graph.

Scenario 5: Disconnected Graph

Details:
  TestName: ProcessAllComponentsInDisconnectedGraph
  Description: Ensure that all components of a disconnected graph are processed.
Execution:
  Arrange: Create a DepthFirstSearch instance and a disconnected IGraph<DFSVertex> with multiple components.
  Act: Call the Run method with the disconnected graph.
  Assert: Verify that all vertices in all components have been processed.
Validation:
  This test checks if the method can handle disconnected graphs and process all components.

Scenario 6: Cyclic Graph

Details:
  TestName: HandleCyclicGraphWithoutInfiniteLoop
  Description: Check if the method can process a graph containing cycles without getting stuck in an infinite loop.
Execution:
  Arrange: Create a DepthFirstSearch instance and an IGraph<DFSVertex> containing at least one cycle.
  Act: Call the Run method with the cyclic graph.
  Assert: Verify that all vertices are processed and the method terminates.
Validation:
  This test ensures that the method can handle graphs with cycles without issues.

Scenario 7: Large Graph

Details:
  TestName: ProcessLargeGraphEfficiently
  Description: Verify that the method can handle a large graph within a reasonable time frame.
Execution:
  Arrange: Create a DepthFirstSearch instance and a large IGraph<DFSVertex> with many vertices and edges.
  Act: Call the Run method with the large graph and measure execution time.
  Assert: Check that all vertices are processed and the execution time is within acceptable limits.
Validation:
  This test confirms that the method scales well for larger graphs and performs efficiently.

Scenario 8: Correct Start and End Times

Details:
  TestName: AssignCorrectStartAndEndTimes
  Description: Ensure that the start and end times for each vertex are assigned correctly and in the right order.
Execution:
  Arrange: Create a DepthFirstSearch instance and an IGraph<DFSVertex> with a known structure.
  Act: Call the Run method with the graph.
  Assert: Verify that for each vertex, StartTime < EndTime, and that the times are consistent with the DFS order.
Validation:
  This test checks the correctness of the core DFS algorithm implementation.

Scenario 9: Proper Predecessor Assignment

Details:
  TestName: AssignProperPredecessors
  Description: Verify that the predecessor for each vertex is correctly assigned during the DFS traversal.
Execution:
  Arrange: Create a DepthFirstSearch instance and an IGraph<DFSVertex> with a known structure.
  Act: Call the Run method with the graph.
  Assert: Check that the Predecessor property for each vertex (except the start vertex) points to the correct parent in the DFS tree.
Validation:
  This test ensures that the DFS tree structure is correctly captured through predecessor assignments.

These test scenarios cover various aspects of the `Run` method, including edge cases, error handling, and core functionality. They should provide a comprehensive test suite for the DepthFirstSearch class.


*/

// ********RoostGPT********
using NUnit.Framework;
using LunarDoggo.Datastructures.Graphs;
using LunarDoggo.Algorithms.Graphs.Pathfinding;
using System;
using System.Linq;

namespace LunarDoggo.Algorithms.Graphs.Pathfinding.Test
{
    [TestFixture]
    public class Run163Test
    {
        private DepthFirstSearch dfs;

        [SetUp]
        public void Setup()
        {
            dfs = new DepthFirstSearch();
        }

        [Test]
        public void ThrowArgumentNullExceptionWhenGraphIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => dfs.Run(null));
        }

        [Test]
        public void RunSuccessfullyOnEmptyGraph()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            Assert.DoesNotThrow(() => dfs.Run(graph));
        }

        [Test]
        public void ProcessSingleVertexGraphCorrectly()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            var vertex = graph.AddVertex(new DFSVertex());

            dfs.Run(graph);

            Assert.That(vertex.Value.Processed, Is.True);
            Assert.That(vertex.Value.StartTime, Is.GreaterThanOrEqualTo(0));
            Assert.That(vertex.Value.EndTime, Is.GreaterThan(vertex.Value.StartTime));
        }

        [Test]
        public void ProcessAllVerticesInConnectedGraph()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            var v1 = graph.AddVertex(new DFSVertex());
            var v2 = graph.AddVertex(new DFSVertex());
            var v3 = graph.AddVertex(new DFSVertex());
            graph.AddEdge(v1, v2);
            graph.AddEdge(v2, v3);

            dfs.Run(graph);

            Assert.That(graph.Vertices.All(v => v.Value.Processed), Is.True);
        }

        [Test]
        public void ProcessAllComponentsInDisconnectedGraph()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            var v1 = graph.AddVertex(new DFSVertex());
            var v2 = graph.AddVertex(new DFSVertex());
            var v3 = graph.AddVertex(new DFSVertex());
            var v4 = graph.AddVertex(new DFSVertex());
            graph.AddEdge(v1, v2);
            graph.AddEdge(v3, v4);

            dfs.Run(graph);

            Assert.That(graph.Vertices.All(v => v.Value.Processed), Is.True);
        }

        [Test]
        public void HandleCyclicGraphWithoutInfiniteLoop()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            var v1 = graph.AddVertex(new DFSVertex());
            var v2 = graph.AddVertex(new DFSVertex());
            var v3 = graph.AddVertex(new DFSVertex());
            graph.AddEdge(v1, v2);
            graph.AddEdge(v2, v3);
            graph.AddEdge(v3, v1);

            dfs.Run(graph);

            Assert.That(graph.Vertices.All(v => v.Value.Processed), Is.True);
        }

        [Test]
        public void ProcessLargeGraphEfficiently()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            for (int i = 0; i < 10000; i++)
            {
                graph.AddVertex(new DFSVertex());
            }

            // TODO: Add edges to create a large connected graph

            var startTime = DateTime.Now;
            dfs.Run(graph);
            var endTime = DateTime.Now;

            Assert.That(graph.Vertices.All(v => v.Value.Processed), Is.True);
            Assert.That((endTime - startTime).TotalSeconds, Is.LessThan(5)); // Adjust timeout as needed
        }

        [Test]
        public void AssignCorrectStartAndEndTimes()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            var v1 = graph.AddVertex(new DFSVertex());
            var v2 = graph.AddVertex(new DFSVertex());
            var v3 = graph.AddVertex(new DFSVertex());
            graph.AddEdge(v1, v2);
            graph.AddEdge(v2, v3);

            dfs.Run(graph);

            foreach (var vertex in graph.Vertices)
            {
                Assert.That(vertex.Value.StartTime, Is.LessThan(vertex.Value.EndTime));
            }

            Assert.That(v1.Value.StartTime, Is.LessThan(v2.Value.StartTime));
            Assert.That(v2.Value.StartTime, Is.LessThan(v3.Value.StartTime));
            Assert.That(v3.Value.EndTime, Is.LessThan(v2.Value.EndTime));
            Assert.That(v2.Value.EndTime, Is.LessThan(v1.Value.EndTime));
        }

        [Test]
        public void AssignProperPredecessors()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            var v1 = graph.AddVertex(new DFSVertex());
            var v2 = graph.AddVertex(new DFSVertex());
            var v3 = graph.AddVertex(new DFSVertex());
            graph.AddEdge(v1, v2);
            graph.AddEdge(v2, v3);

            dfs.Run(graph);

            Assert.That(v1.Value.Predecessor, Is.Null);
            Assert.That(v2.Value.Predecessor, Is.EqualTo(v1));
            Assert.That(v3.Value.Predecessor, Is.EqualTo(v2));
        }
    }
}
