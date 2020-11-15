﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace WarspiteGame.AuthoringTools.Formats
{
    public class WarspiteStateFile
    {
        public WarspiteStateFile()
        {

        }

        public WarspiteStateFile(WarspiteStateFile wsf)
        {
            states = wsf.states;
            type = wsf.type;
        }

        [Browsable(false)]
        public List<WarspiteState> states { get; set; } = new List<WarspiteState>();

        [Browsable(false)] 
        public string type { get; set; } = "StateFile";

        public override bool Equals(object obj)
        {
            var o = obj as WarspiteStateFile;

            if (o == null)
                return false;

            if (!states.SequenceEqual(o.states))
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            return states.GetHashCode() * type.GetHashCode() * 21;
        }
    }

    public class WarspiteState
    {
        [Category("State Metadata")]
        [DisplayName("Identifier")]
        [Description("The identifier used to load the state.")]
        public string id { get; set; }

        [Category("State Data")]
        [DisplayName("Textures")]
        [Description("A list of textures that will be loaded when the Engine loads the state.")]
        public AssetContainer[] textures { get; set; } = { };

        [Category("State Data")]
        [DisplayName("Scripts")]
        [Description("A list of scripts that will be loaded when the Engine loads the state.")]
        public AssetContainer[] scripts { get; set; } = { };

        [Category("State Data")]
        [DisplayName("Objects")]
        [Description("A list of objects that will be created when the Engine loads the state.")]
        public ObjectContainer[] objects { get; set; } = { };

        public override bool Equals(object obj)
        {
            var o = obj as WarspiteState;

            if (o == null)
                return false;

            if (id != o.id || !textures.SequenceEqual(o.textures) || !scripts.SequenceEqual(o.scripts) || !objects.SequenceEqual(o.objects))
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode() * textures.GetHashCode() * scripts.GetHashCode() * objects.GetHashCode() * 21;
        }
    }

    public class AssetContainer
    {
        [Category("Asset Information")]
        [DisplayName("Identifier")]
        [Description("The identifier used to reference the asset within the state.")]
        public string id { get; set; } = "";

        [Category("Asset Information")]
        [DisplayName("Path")]
        [Description("The path to load the asset - relative to the folder of the type of asset. (e.g. Textures will be loaded from \"assets/textures\")")]
        public string path { get; set; } = "";

        public override bool Equals(object obj)
        {
            var o = obj as AssetContainer;

            if (o == null)
                return false;

            if (id != o.id || path != o.path)
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode() * path.GetHashCode() * 21;
        }
    }

    public class ObjectContainer
    {
        [Category("Object Information")]
        [DisplayName("Name")]
        [Description("The name of this instance of the object that will be created.")]
        public string name { get; set; } = "";

        [Category("Object Information")]
        [DisplayName("Type")]
        [Description("The type of the object that will be created.")]
        public string type { get; set; } = "";

        [Category("Object Information")]
        [DisplayName("Texture ID")]
        [Description("The ID of the texture that this object will use. ID are loaded in the state.")]
        public string textureid { get; set; } = "";

        [Category("Object Information")]
        [DisplayName("Script")]
        [Description("The ID of the script that this object will use. ID are loaded in the state.")]
        public string script { get; set; } = "";

        [Category("Object Information")]
        [DisplayName("Sound Path")]
        [Description("The path of the sound that would be used by the object.")]
        public string soundPath { get; set; } = "";

        [Category("Object Information")]
        [DisplayName("X")]
        [Description("The X position of the object on the screen.")]
        public int x { get; set; } = 0;

        [Category("Object Information")]
        [DisplayName("Y")]
        [Description("The Y position of the object on the screen.")]
        public int y { get; set; } = 0;

        [Category("Object Information")]
        [DisplayName("Width")]
        [Description("The width of the object.")]
        public int width { get; set; } = 0;

        [Category("Object Information")]
        [DisplayName("Height")]
        [Description("The height of the object.")]
        public int height { get; set; } = 0;

        [Category("Object Information")]
        [DisplayName("Number of frames")]
        [Description("The number of frames of animation that the object has on its texture sheet.")]
        public int numFrames { get; set; } = 1;

        [Category("Object Information")]
        [DisplayName("Animation Speed")]
        [Description("The speed that texture animation will playback.")]
        public int animSpeed { get; set; } = 1;

        [Category("Object Callbacks")]
        [DisplayName("On Click Event")]
        [Description("The hardcoded event that will execute on click in the callback array in the state.")]
        public int onClickId { get; set; } = 0;

        [Category("Object Callbacks")]
        [DisplayName("On Enter Event")]
        [Description("The hardcoded event that will execute on mouse entry in the callback array in the state.")]
        public int onEnterId { get; set; } = 0;

        [Category("Object Callbacks")]
        [DisplayName("On Leave Event")]
        [Description("The hardcoded event that will execute on mouse leave in the callback array in the state.")]
        public int onLeaveId { get; set; } = 0;

        public override bool Equals(object obj)
        {
            var o = obj as ObjectContainer;

            if (o == null)
                return false;

            // ew
            if (name != o.name || type != o.type || textureid != o.textureid || script != o.script || x != o.x || y != o.y
                || width != o.width || height != o.height || numFrames != o.numFrames || animSpeed != o.animSpeed
                || onClickId != o.onClickId || onEnterId != o.onEnterId || onLeaveId != o.onLeaveId)
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            return name.GetHashCode() * type.GetHashCode() * textureid.GetHashCode() 
                   * script.GetHashCode() * x.GetHashCode() * y.GetHashCode() *
                   width.GetHashCode() * height.GetHashCode() * numFrames.GetHashCode() *
                animSpeed.GetHashCode() * onClickId.GetHashCode() * onEnterId.GetHashCode() 
                   * onLeaveId.GetHashCode() * 21;
        }
    }
}