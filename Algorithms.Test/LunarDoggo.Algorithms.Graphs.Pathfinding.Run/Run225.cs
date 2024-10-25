// ********RoostGPT********
/*
Test generated by RoostGPT for test sampleCSharpEnv using AI Type  and AI Model 

ROOST_METHOD_HASH=Run_a2e9436d0a
ROOST_METHOD_SIG_HASH=Run_9ce955ed80

   ########## Test-Scenarios ##########  

Based on the provided method and related code, here are several test scenarios for the `Run` method of the `DepthFirstSearch` class:

Scenario 1: Null Graph Input

Details:
  TestName: ThrowsArgumentNullExceptionForNullGraph
  Description: Verify that the method throws an ArgumentNullException when a null graph is provided.
Execution:
  Arrange: Create a DepthFirstSearch instance.
  Act: Call the Run method with a null graph.
  Assert: Expect an ArgumentNullException to be thrown.
Validation:
  This test ensures that the method properly handles null input, preventing potential null reference exceptions later in the execution.

Scenario 2: Empty Graph

Details:
  TestName: ProcessesEmptyGraphWithoutErrors
  Description: Ensure the method can handle an empty graph (a graph with no vertices) without throwing exceptions.
Execution:
  Arrange: Create a DepthFirstSearch instance and an empty IGraph<DFSVertex>.
  Act: Call the Run method with the empty graph.
  Assert: Verify that no exception is thrown and the method completes successfully.
Validation:
  This test confirms that the method can handle edge cases like empty graphs gracefully.

Scenario 3: Single Vertex Graph

Details:
  TestName: ProcessesSingleVertexGraphCorrectly
  Description: Verify that the method correctly processes a graph with a single vertex.
Execution:
  Arrange: Create a DepthFirstSearch instance and an IGraph<DFSVertex> with one vertex.
  Act: Call the Run method with the single-vertex graph.
  Assert: Check that the vertex's StartTime and EndTime are set and Processed is true.
Validation:
  This test ensures that the basic functionality works for the simplest possible graph.

Scenario 4: Fully Connected Graph

Details:
  TestName: ProcessesFullyConnectedGraphCorrectly
  Description: Ensure the method correctly processes a fully connected graph (where every vertex is connected to every other vertex).
Execution:
  Arrange: Create a DepthFirstSearch instance and a fully connected IGraph<DFSVertex>.
  Act: Call the Run method with the fully connected graph.
  Assert: Verify that all vertices are processed, have valid StartTime and EndTime values, and form a valid DFS tree.
Validation:
  This test checks if the method can handle complex graph structures without issues.

Scenario 5: Disconnected Graph

Details:
  TestName: ProcessesDisconnectedGraphCorrectly
  Description: Verify that the method correctly processes a graph with multiple disconnected components.
Execution:
  Arrange: Create a DepthFirstSearch instance and an IGraph<DFSVertex> with multiple disconnected subgraphs.
  Act: Call the Run method with the disconnected graph.
  Assert: Check that all vertices in all components are processed and have valid StartTime and EndTime values.
Validation:
  This test ensures that the method can handle graphs that are not fully connected, processing all components.

Scenario 6: Cyclic Graph

Details:
  TestName: HandlesCyclicGraphWithoutInfiniteLoop
  Description: Ensure the method can process a graph containing cycles without entering an infinite loop.
Execution:
  Arrange: Create a DepthFirstSearch instance and an IGraph<DFSVertex> containing at least one cycle.
  Act: Call the Run method with the cyclic graph.
  Assert: Verify that all vertices are processed, have valid StartTime and EndTime values, and the method terminates.
Validation:
  This test checks if the method can handle graphs with cycles, which is crucial for preventing infinite recursion.

Scenario 7: Large Graph Performance

Details:
  TestName: ProcessesLargeGraphInReasonableTime
  Description: Verify that the method can process a large graph within a reasonable time frame.
Execution:
  Arrange: Create a DepthFirstSearch instance and a large IGraph<DFSVertex> (e.g., 10000+ vertices).
  Act: Call the Run method with the large graph and measure execution time.
  Assert: Check that all vertices are processed and the execution time is within an acceptable range.
Validation:
  This test ensures that the method's performance scales well with larger graphs.

Scenario 8: Graph with Pre-initialized Vertices

Details:
  TestName: CorrectlyReInitializesPreProcessedVertices
  Description: Ensure the method correctly reinitializes vertices that have been previously processed.
Execution:
  Arrange: Create a DepthFirstSearch instance and an IGraph<DFSVertex> where some vertices have non-default StartTime, EndTime, or Predecessor values.
  Act: Call the Run method with this graph.
  Assert: Verify that all vertices are reinitialized and processed correctly, regardless of their initial state.
Validation:
  This test checks if the method properly handles graphs where vertices might have been previously processed or partially initialized.

These test scenarios cover various aspects of the `Run` method, including edge cases, error handling, and different graph structures. They aim to ensure the robustness and correctness of the Depth-First Search implementation.


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
    public class Run225Test
    {
        private DepthFirstSearch dfs;

        [SetUp]
        public void Setup()
        {
            dfs = new DepthFirstSearch();
        }

        [Test, Category("invalid")]
        public void ThrowsArgumentNullExceptionForNullGraph()
        {
            Assert.Throws<ArgumentNullException>(() => dfs.Run(null));
        }

        [Test, Category("valid")]
        public void ProcessesEmptyGraphWithoutErrors()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            Assert.DoesNotThrow(() => dfs.Run(graph));
        }

        [Test, Category("valid")]
        public void ProcessesSingleVertexGraphCorrectly()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            var vertex = graph.AddVertex(new DFSVertex());

            dfs.Run(graph);

            Assert.That(vertex.Value.Processed, Is.True);
            Assert.That(vertex.Value.StartTime, Is.GreaterThanOrEqualTo(0));
            Assert.That(vertex.Value.EndTime, Is.GreaterThan(vertex.Value.StartTime));
        }

        [Test, Category("valid")]
        public void ProcessesFullyConnectedGraphCorrectly()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            var vertices = Enumerable.Range(0, 5).Select(_ => graph.AddVertex(new DFSVertex())).ToList();

            for (int i = 0; i < vertices.Count; i++)
            {
                for (int j = i + 1; j < vertices.Count; j++)
                {
                    graph.AddEdge(vertices[i], vertices[j]);
                }
            }

            dfs.Run(graph);

            Assert.That(vertices.All(v => v.Value.Processed), Is.True);
            Assert.That(vertices.All(v => v.Value.StartTime >= 0), Is.True);
            Assert.That(vertices.All(v => v.Value.EndTime > v.Value.StartTime), Is.True);
        }

        [Test, Category("valid")]
        public void ProcessesDisconnectedGraphCorrectly()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            var component1 = new[] { graph.AddVertex(new DFSVertex()), graph.AddVertex(new DFSVertex()) };
            var component2 = new[] { graph.AddVertex(new DFSVertex()), graph.AddVertex(new DFSVertex()) };

            graph.AddEdge(component1[0], component1[1]);
            graph.AddEdge(component2[0], component2[1]);

            dfs.Run(graph);

            Assert.That(graph.Vertices.All(v => v.Value.Processed), Is.True);
            Assert.That(graph.Vertices.All(v => v.Value.StartTime >= 0), Is.True);
            Assert.That(graph.Vertices.All(v => v.Value.EndTime > v.Value.StartTime), Is.True);
        }

        [Test, Category("valid")]
        public void HandlesCyclicGraphWithoutInfiniteLoop()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            var v1 = graph.AddVertex(new DFSVertex());
            var v2 = graph.AddVertex(new DFSVertex());
            var v3 = graph.AddVertex(new DFSVertex());

            graph.AddEdge(v1, v2);
            graph.AddEdge(v2, v3);
            graph.AddEdge(v3, v1);

            Assert.DoesNotThrow(() => dfs.Run(graph));
            Assert.That(graph.Vertices.All(v => v.Value.Processed), Is.True);
        }

        [Test, Category("valid")]
        public void ProcessesLargeGraphInReasonableTime()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            var vertices = Enumerable.Range(0, 10000).Select(_ => graph.AddVertex(new DFSVertex())).ToList();

            for (int i = 1; i < vertices.Count; i++)
            {
                graph.AddEdge(vertices[i - 1], vertices[i]);
            }

            var startTime = DateTime.Now;
            dfs.Run(graph);
            var duration = DateTime.Now - startTime;

            Assert.That(duration.TotalSeconds, Is.LessThan(5)); // Adjust the time limit as needed
            Assert.That(graph.Vertices.All(v => v.Value.Processed), Is.True);
        }

        [Test, Category("valid")]
        public void CorrectlyReInitializesPreProcessedVertices()
        {
            var graph = new UndirectedUnweightedGraph<DFSVertex>();
            var v1 = graph.AddVertex(new DFSVertex { StartTime = 1, EndTime = 2 });
            var v2 = graph.AddVertex(new DFSVertex { StartTime = 3, EndTime = 4 });
            graph.AddEdge(v1, v2);

            dfs.Run(graph);

            Assert.That(v1.Value.StartTime, Is.Not.EqualTo(1));
            Assert.That(v1.Value.EndTime, Is.Not.EqualTo(2));
            Assert.That(v2.Value.StartTime, Is.Not.EqualTo(3));
            Assert.That(v2.Value.EndTime, Is.Not.EqualTo(4));
            Assert.That(graph.Vertices.All(v => v.Value.Processed), Is.True);
        }
    }
}
