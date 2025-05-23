using System.Collections;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;
using System.Reflection;
using System.Linq;

namespace UnityEditor.TerrainTools
{

    [TestFixture]
    internal class PaintDetails
    {
        private TerrainData mData;
        private GameObject mTerrainGO;
        private static string terrainDataPath = "Assets/TerrainPaintDetails.asset";

        [SetUp]
        public void SetUp()
        {
            mData = new TerrainData();
            AssetDatabase.CreateAsset(mData, terrainDataPath);
            mData.heightmapResolution = 257;
            mData.alphamapResolution = 256;
            mData.size = new Vector3(256, 20, 256);
            mData.baseMapResolution = 256;
            mData.SetDetailResolution(256, mData.detailResolutionPerPatch);

            mTerrainGO = Terrain.CreateTerrainGameObject(mData);
            mTerrainGO.name = "TestTerrain";
        }

        [TearDown]
        public void TearDown()
        {
            GameObject.DestroyImmediate(mTerrainGO);
            AssetDatabase.DeleteAsset(terrainDataPath);
        }

        [UnityTest]
        [Ignore("Faulty test using core tool and reflection")]
        /// Tests whether the terrain inspector can survive having a missing detail prototype
        public IEnumerator MissingDetails()
        {
            // Set up a terrain with a detail set up
            DetailPrototype[] prototypes = new DetailPrototype[3];
            prototypes[0] = new DetailPrototype();
            prototypes[0].renderMode = DetailRenderMode.GrassBillboard;
            prototypes[0].density = 1.25f;
            prototypes[0].maxHeight = 1;
            prototypes[0].minHeight = 1;
            prototypes[0].maxWidth = 1;
            prototypes[0].minWidth = 1;
            prototypes[0].positionJitter = 0.5f;
            prototypes[0].useInstancing = true;
            prototypes[0].usePrototypeMesh = true;
            prototypes[0].prototypeTexture = Texture2D.redTexture;

            prototypes[1] = new DetailPrototype();
            prototypes[1].renderMode = DetailRenderMode.GrassBillboard;
            prototypes[1].density = 1.25f;
            prototypes[1].maxHeight = 1;
            prototypes[1].minHeight = 1;
            prototypes[1].maxWidth = 1;
            prototypes[1].minWidth = 1;
            prototypes[1].positionJitter = 0.5f;
            prototypes[1].useInstancing = true;
            prototypes[1].usePrototypeMesh = true;
            prototypes[1].prototypeTexture = null;

            prototypes[2] = new DetailPrototype();
            prototypes[2].renderMode = DetailRenderMode.VertexLit;
            prototypes[2].density = 1.25f;
            prototypes[2].maxHeight = 1;
            prototypes[2].minHeight = 1;
            prototypes[2].maxWidth = 1;
            prototypes[2].minWidth = 1;
            prototypes[2].positionJitter = 0.5f;
            prototypes[2].useInstancing = true;
            prototypes[2].usePrototypeMesh = true;
            prototypes[2].prototype = null;

            mData.detailPrototypes = prototypes;

            yield return null;

            Selection.activeObject = mTerrainGO;
            
            // We have to get the terrain inspector and paint details tool via reflection, as they are internal.
            var terrainInpspector = Editor.CreateEditor(mTerrainGO.GetComponent<Terrain>());
            var terrainInspectorType = terrainInpspector.GetType();
            var selectPaintToolMethod =
                terrainInspectorType.GetMethods().FirstOrDefault(x => x.Name == "SelectPaintTool");

            // October 6 2022: In core (engine) the tool is called PaintDetailsTool. Package
            // overrides that tool with one named DetailScatterTool
            // October 6 2022: DetailScatterTool is in Assembly Unity.TerrainTools.Editor and
            // just need _any_ public type in that Assembly in order to get ahold of DetailScatterTool.
            var paintDetailsType =
                typeof(DetailUtility).Assembly.GetType(
                    "UnityEditor.TerrainTools.DetailScatterTool");

            // select the paint tool.
            selectPaintToolMethod.Invoke(terrainInpspector, new object[] { paintDetailsType });

            yield return null;
        }
    }
}
