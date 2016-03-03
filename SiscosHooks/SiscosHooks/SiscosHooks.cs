﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace SiscosHooks
{
    /// <summary>
    /// Hook functions may return either NULL or an instance of 'Sisco_Return'.
    /// </summary>
    /// <param name="sender">the triggering functions 'this' instance.</param>
    /// <param name="args">reference to the triggering functions args list.</param>
    /// <returns></returns>
    public delegate Sisco_Return Sisco_Hook_Delegate(ref object sender, ref object[] args);

    /// <summary>
    /// yeah I named it after myself, wanna fight about it? Tough guy?!?
    /// </summary>
    public static class SiscoHook
    {
        public const string VERSION = "1.0";// XXX: Make a custom version class thing for SiscosPluginLoader
        private static Dictionary<HOOK_ID, List<Sisco_Hook_Delegate>> events = new Dictionary<HOOK_ID, List<Sisco_Hook_Delegate>>();
        private static Dictionary<object, List<Sisco_Hook_Ref>> tracker = new Dictionary<object, List<Sisco_Hook_Ref>>();

        public static void Init()
        {
            //DebugHud.Init();
        }

        public static _hook_result call(HOOK_ID hook, ref object sender, params object[] args)
        {
            _hook_result result = new _hook_result(false, args);
            try
            {
                List<Sisco_Hook_Delegate> cb_list;
                bool r = SiscoHook.events.TryGetValue(hook, out cb_list);
                if (r == false) return result;//no abort

                
                foreach (Sisco_Hook_Delegate act in cb_list)
                {
                    try
                    {
                        Sisco_Return ret = act(ref sender, ref result.args);
                        if (ret != null)
                        {
                            if (ret.has_custom_return == true)
                            {
                                result.has_custom_return = true;
                                result.return_value = ret.return_value;
                            }

                            if (ret.abort)
                            {
                                break;//cancel all other events
                            }

                            if (ret.handled == true) break;
                        }
                    }
                    catch(Exception ex)
                    {
                        Log(ex.Message);
                        return new _hook_result();
                    }
                }
            }
            catch(Exception ex)
            {
                Log(ex.Message);
                return new _hook_result();
            }

            return result;//no abort
        }

        /// <summary>
        /// Register your own function to be called whenever a specified event triggers.
        /// </summary>
        /// <param name="registrar">Unique identifier used for grouping many hooks into a category for efficient removal later.</param>
        /// <param name="hook">Id of the event to hook.</param>
        /// <param name="cb">The function to call.</param>
        /// <returns>(BOOL) Whether the event was successfully hooked.</returns>
        public static bool register(object registrar, HOOK_ID hook, Sisco_Hook_Delegate cb)
        {
            if (registrar == null)
            {
                Log("Registrar cannot be NULL!");
                return false;
            }

            try
            {
                // create the callback list for this hook type if it doesn't exist.
                List<Sisco_Hook_Delegate> cb_list;
                if (!SiscoHook.events.TryGetValue(hook, out cb_list)) SiscoHook.events[hook] = new List<Sisco_Hook_Delegate>();

                // create this registrar's hooks list if it doesn't exist.
                List<Sisco_Hook_Ref> hooks_list;
                if (!SiscoHook.tracker.TryGetValue(registrar, out hooks_list)) SiscoHook.tracker[registrar] = new List<Sisco_Hook_Ref>();

                //add this hook to their list.
                SiscoHook.tracker[registrar].Add(new Sisco_Hook_Ref(hook, cb));
                SiscoHook.events[hook].Add(cb);
                return true;
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }

            return false;
        }


        /// <summary>
        /// Unhook a previous hook you installed.
        /// </summary>
        /// <param name="registrar">Unique identifier used for grouping many hooks into a category for efficient removal later.</param>
        /// <param name="hook">Id of the event to unhook.</param>
        /// <param name="cb">The function to call.</param>
        /// <returns>(BOOL) Whether the event was successfully unhooked.</returns>
        public static bool unregister(object registrar, HOOK_ID hook, Sisco_Hook_Delegate cb)
        {
            if (registrar == null)
            {
                Log("Registrar cannot be NULL!");
                return false;
            }

            try
            {
                // create the callback list for this hook type if it doesn't exist.
                List<Sisco_Hook_Delegate> cb_list;
                if (!SiscoHook.events.TryGetValue(hook, out cb_list)) SiscoHook.events[hook] = new List<Sisco_Hook_Delegate>();

                // create this registrar's hooks list if it doesn't exist.
                List<Sisco_Hook_Ref> hooks_list;
                if (!SiscoHook.tracker.TryGetValue(registrar, out hooks_list)) SiscoHook.tracker[registrar] = new List<Sisco_Hook_Ref>();

                //add this hook to their list.
                bool tr_success = SiscoHook.tracker[registrar].Remove(new Sisco_Hook_Ref(hook, cb));
                if (!tr_success)
                {
                    Log("Failed to remove hook from tracker. Sender({0})", registrar);
                    return false;
                }

                bool hk_success = SiscoHook.events[hook].Remove(cb);
                if (!hk_success)
                {
                    Log("Failed to remove hook from hooks list. Sender({0})", registrar);
                    return false;
                }

                return (tr_success && hk_success);
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }

            return false;
        }


        /// <summary>
        /// Unhook ALL of the previous hooks you installed with a specified registrar object.
        /// </summary>
        /// <param name="registrar">Unique identifier used for grouping many hooks into a category for efficient removal later.</param>
        /// <param name="hook">Id of the event to unhook. Leave this blank to remove ALL hooked events.</param>
        /// <returns>(BOOL) Whether the events was successfully unhooked.</returns>
        public static bool unregister_all(object registrar, HOOK_ID hook=HOOK_ID.NONE)
        {
            if (registrar == null)
            {
                Log("Registrar cannot be NULL!");
                return false;
            }

            try
            {
                // create the callback list for this hook type if it doesn't exist.
                List<Sisco_Hook_Delegate> cb_list;
                if (!SiscoHook.events.TryGetValue(hook, out cb_list)) SiscoHook.events[hook] = new List<Sisco_Hook_Delegate>();

                // create this registrar's hooks list if it doesn't exist.
                List<Sisco_Hook_Ref> hooks_list;
                if (!SiscoHook.tracker.TryGetValue(registrar, out hooks_list)) SiscoHook.tracker[registrar] = new List<Sisco_Hook_Ref>();
                
                foreach(var o in hooks_list)
                {
                    if (hook != HOOK_ID.NONE && o.evt != hook) continue;
                    bool b = unregister(registrar, o.evt, o.callback);
                    if(!b)
                    {
                        Log("");
                    }
                }
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }

            return false;
        }

        private static void Log(string format, params object[] args)
        {
            string tag = "[SiscosHooks]";
            //DebugHud.Log(tag+" "+format, args);
            UnityEngine.Debug.LogErrorFormat(tag + " " + format, args);
        }


        public static bool Example2(ref int count)
        {
            return true;
        }

        public static _hook_result Example3(object sender, params object[] o)
        {
            object[] obj = new object[2];
            obj[0] = 6;
            obj[1] = "hello world";

            return new _hook_result(false, obj);
        }

        public static void Example(int count, string str)
        {
            Example2(ref count);
        }
    }
}
