// $begin{copyright}
//
// This file is part of WebSharper
//
// Copyright (c) 2008-2016 IntelliFactory
//
// Licensed under the Apache License, Version 2.0 (the "License"); you
// may not use this file except in compliance with the License.  You may
// obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or
// implied.  See the License for the specific language governing
// permissions and limitations under the License.
//
// $end{copyright}

IntelliFactory = {
    Runtime: {
        Ctor: function (ctor, typeFunction) {
            ctor.prototype = typeFunction.prototype;
            return ctor;
        },

        Class: function (members, base, statics) {
            var proto = members;
            if (base) {
                proto = new base();
                for (var m in members) { proto[m] = members[m] }
            }
            var typeFunction = function (copyFrom) {
                if (copyFrom) {
                    for (var f in copyFrom) { this[f] = copyFrom[f] }
                }
            }
            typeFunction.prototype = proto;
            if (statics) {
                for (var f in statics) { typeFunction[f] = statics[f] }
            }
            return typeFunction;
        },

        Clone: function (obj) {
            var res = {};
            for (var p in obj) { res[p] = obj[p] }
            return res;
        },

        NewObject:
            function (kv) {
                var o = {};
                for (var i = 0; i < kv.length; i++) {
                    o[kv[i][0]] = kv[i][1];
                }
                return o;
            },

        DeleteEmptyFields:
            function (obj, fields) {
                for (var i = 0; i < fields.length; i++) {
                    var f = fields[i];
                    if (obj[f] === void (0)) { delete obj[f]; }
                }
                return obj;
            },

        GetOptional:
            function (value) {
                return (value === void (0)) ? null : { $: 1, $0: value };
            },

        SetOptional:
            function (obj, field, value) {
                if (value) {
                    obj[field] = value.$0;
                } else {
                    delete obj[field];
                }
            },

        SetOrDelete:
            function (obj, field, value) {
                if (value === void (0)) {
                    delete obj[field];
                } else {
                    obj[field] = value;
                }
            },

        Apply: function (f, obj, args) {
            return f.apply(obj, args);
        },

        Bind: function (f, obj) {
            return function () { return f.apply(this, arguments) };
        },

        CreateFuncWithArgs: function (f) {
            return function () { return f(Array.prototype.slice.call(arguments)) };
        },

        CreateFuncWithOnlyThis: function (f) {
            return function () { return f(this) };
        },

        CreateFuncWithThis: function (f) {
            return function () { return f(this).apply(null, arguments) };
        },

        CreateFuncWithThisArgs: function (f) {
            return function () { return f(this)(Array.prototype.slice.call(arguments)) };
        },

        CreateFuncWithRest: function (length, f) {
            return function () { return f(Array.prototype.slice.call(arguments, 0, length).concat([Array.prototype.slice.call(arguments, length)])) };
        },

        CreateFuncWithArgsRest: function (length, f) {
            return function () { return f([Array.prototype.slice.call(arguments, 0, length), Array.prototype.slice.call(arguments, length)]) };
        },

        BindDelegate: function (func, obj) {
            var res = func.bind(obj);
            res.$Func = func;
            res.$Target = obj;
            return res;
        },

        CreateDelegate: function (invokes) {
            if (invokes.length == 0) return null;
            if (invokes.length == 1) return invokes[0];
            var del = function () {
                var res;
                for (var i = 0; i < invokes.length; i++) {
                    res = invokes[i].apply(null, arguments);
                }
                return res;
            };
            del.$Invokes = invokes;
            return del;
        },

        CombineDelegates: function (dels) {
            var invokes = [];
            for (var i = 0; i < dels.length; i++) {
                var del = dels[i];
                if (del) {
                    if ("$Invokes" in del)
                        invokes = invokes.concat(del.$Invokes);
                    else
                        invokes.push(del);
                }
            }
            return IntelliFactory.Runtime.CreateDelegate(invokes);
        },

        DelegateEqual: function (d1, d2) {
            if (d1 === d2) return true;
            if (d1 == null || d2 == null) return false;
            var i1 = d1.$Invokes || [d1];
            var i2 = d2.$Invokes || [d2];
            if (i1.length != i2.length) return false;
            for (var i = 0; i < i1.length; i++) {
                var e1 = i1[i];
                var e2 = i2[i];
                if (!(e1 === e2 || ("$Func" in e1 && "$Func" in e2 && e1.$Func === e2.$Func && e1.$Target == e2.$Target)))
                    return false;
            }
            return true;
        },

        ThisFunc: function (d) {
            return function () {
                var args = Array.prototype.slice.call(arguments);
                args.unshift(this);
                return d.apply(null, args);
            };
        },

        ThisFuncOut: function (f) {
            return function () {
                var args = Array.prototype.slice.call(arguments);
                return f.apply(args.shift(), args);
            };
        },

        ParamsFunc: function (length, d) {
            return function () {
                var args = Array.prototype.slice.call(arguments);
                return d.apply(null, args.slice(0, length).concat([args.slice(length)]));
            };
        },

        ParamsFuncOut: function (length, f) {
            return function () {
                var args = Array.prototype.slice.call(arguments);
                return f.apply(null, args.slice(0, length).concat(args[length]));
            };
        },

        ThisParamsFunc: function (length, d) {
            return function () {
                var args = Array.prototype.slice.call(arguments);
                args.unshift(this);
                return d.apply(null, args.slice(0, length + 1).concat([args.slice(length + 1)]));
            };
        },

        ThisParamsFuncOut: function (length, f) {
            return function () {
                var args = Array.prototype.slice.call(arguments);
                return f.apply(args.shift(), args.slice(0, length).concat(args[length]));
            };
        },

        Curried: function (f, n, args) {
            args = args || [];
            return function (a) {
                var allArgs = args.concat([a === void (0) ? null : a]);
                if (n == 1)
                    return f.apply(null, allArgs);
                if (n == 2)
                    return function (a) { return f.apply(null, allArgs.concat([a === void (0) ? null : a])); }
                return IntelliFactory.Runtime.Curried(f, n - 1, allArgs);
            }
        },

        Curried2: function (f) {
            return function (a) { return function (b) { return f(a, b); } }
        },

        Curried3: function (f) {
            return function (a) { return function (b) { return function (c) { return f(a, b, c); } } }
        },

        UnionByType: function (types, value, optional) {
            var vt = typeof value;
            for (var i = 0; i < types.length; i++) {
                var t = types[i];
                if (typeof t == "number") {
                    if (Array.isArray(value) && (t == 0 || value.length == t)) {
                        return { $: i, $0: value };
                    }
                } else {
                    if (t == vt) {
                        return { $: i, $0: value };
                    }
                }
            }
            if (!optional) {
                throw new Error("Type not expected for creating Choice value.");
            }
        },

        ScriptBasePath: "./",

        ScriptPath: function (a, f) {
            return this.ScriptBasePath + (this.ScriptSkipAssemblyDir ? "" : a + "/") + f;
        },

        OnLoad:
            function (f) {
                if (!("load" in this)) {
                    this.load = [];
                }
                this.load.push(f);
            },

        Start:
            function () {
                function run(c) {
                    for (var i = 0; i < c.length; i++) {
                        c[i]();
                    }
                }
                if ("load" in this) {
                    run(this.load);
                    this.load = [];
                }
            },
    }
}

IntelliFactory.Runtime.OnLoad(function () {
    if (self.WebSharper && WebSharper.Activator && WebSharper.Activator.Activate)
        WebSharper.Activator.Activate()
});

// Polyfill

if (!Date.now) {
    Date.now = function () {
        return new Date().getTime();
    };
}

if (!Math.trunc) {
    Math.trunc = function (x) {
        return x < 0 ? Math.ceil(x) : Math.floor(x);
    }
}

if (!Object.setPrototypeOf) {
  Object.setPrototypeOf = function (obj, proto) {
    obj.__proto__ = proto;
    return obj;
  }
}

function ignore() { };
function id(x) { return x };
function fst(x) { return x[0] };
function snd(x) { return x[1] };
function trd(x) { return x[2] };

if (!console) {
    console = {
        count: ignore,
        dir: ignore,
        error: ignore,
        group: ignore,
        groupEnd: ignore,
        info: ignore,
        log: ignore,
        profile: ignore,
        profileEnd: ignore,
        time: ignore,
        timeEnd: ignore,
        trace: ignore,
        warn: ignore
    }
};
(function()
{
 "use strict";
 var Global,WebSharper,MaterialUI,Tests,Client,Operators,React,Component,Main,React$1,ReactModule,EventTarget,Node,JavaScript,Pervasives,Arrays,Unchecked,Ref,State,WindowOrWorkerGlobalScope,SC$1,List,T,Enumerator,Task,Obj,Error,InvalidOperationException,T$1,Object,Seq,ReactDOM,IntelliFactory,Runtime;
 Global=self;
 WebSharper=Global.WebSharper=Global.WebSharper||{};
 MaterialUI=WebSharper.MaterialUI=WebSharper.MaterialUI||{};
 Tests=MaterialUI.Tests=MaterialUI.Tests||{};
 Client=Tests.Client=Tests.Client||{};
 Operators=WebSharper.Operators=WebSharper.Operators||{};
 React=Global.React;
 Component=React&&React.Component;
 Main=Client.Main=Client.Main||{};
 React$1=WebSharper.React=WebSharper.React||{};
 ReactModule=React$1.ReactModule=React$1.ReactModule||{};
 EventTarget=Global.EventTarget;
 Node=Global.Node;
 JavaScript=WebSharper.JavaScript=WebSharper.JavaScript||{};
 Pervasives=JavaScript.Pervasives=JavaScript.Pervasives||{};
 Arrays=WebSharper.Arrays=WebSharper.Arrays||{};
 Unchecked=WebSharper.Unchecked=WebSharper.Unchecked||{};
 Ref=WebSharper.Ref=WebSharper.Ref||{};
 State=Client.State=Client.State||{};
 WindowOrWorkerGlobalScope=Global.WindowOrWorkerGlobalScope;
 SC$1=Global.StartupCode$WebSharper_MaterialUI_Tests$Client=Global.StartupCode$WebSharper_MaterialUI_Tests$Client||{};
 List=WebSharper.List=WebSharper.List||{};
 T=List.T=List.T||{};
 Enumerator=WebSharper.Enumerator=WebSharper.Enumerator||{};
 Task=Client.Task=Client.Task||{};
 Obj=WebSharper.Obj=WebSharper.Obj||{};
 Error=Global.Error;
 InvalidOperationException=WebSharper.InvalidOperationException=WebSharper.InvalidOperationException||{};
 T$1=Enumerator.T=Enumerator.T||{};
 Object=Global.Object;
 Seq=WebSharper.Seq=WebSharper.Seq||{};
 ReactDOM=Global.ReactDOM;
 IntelliFactory=Global.IntelliFactory;
 Runtime=IntelliFactory&&IntelliFactory.Runtime;
 Client.Main$1=function()
 {
  var theme,config,children;
  ReactDOM.render((theme=(config=Client.MyTheme(),self["material-ui"].createMuiTheme(config)),(children=[React.createElement(self["material-ui"].CssBaseline,null),React.createElement((self["material-ui"].withStyles(Client.MyStyles))(Main.New),null)],React.createElement(self["material-ui"].MuiThemeProvider,{
   theme:theme
  },Arrays.ofSeq(children)))),self.document.body);
 };
 Client.MyStyles=function(theme)
 {
  return{
   root:{
    marginTop:theme.spacing.unit,
    marginBottom:theme.spacing.unit,
    marginLeft:theme.spacing.unit,
    marginRight:theme.spacing.unit,
    flex:1,
    display:"flex",
    flexDirection:"column"
   },
   list:{
    flex:1,
    overflowY:"auto"
   }
  };
 };
 Client.MyTheme=function()
 {
  SC$1.$cctor();
  return SC$1.MyTheme;
 };
 Operators.InvalidOp=function(msg)
 {
  throw new InvalidOperationException.New(msg);
 };
 Operators.FailWith=function(msg)
 {
  throw new Error(msg);
 };
 Main=Client.Main=Runtime.Class({
  render:function()
  {
   var $this,props,children,props$1,children$1,props$2;
   $this=this;
   props=[["className",this.props.classes.root]];
   children=[ReactModule.elt(self["material-ui"].Button,[["variant","contained"],["fullWidth",true],["color","secondary"],["onClick",function()
   {
    $this.ClearCompleted();
   }]],["Clear completed tasks"]),(props$1=[["className",this.props.classes.list],["subheader",ReactModule.elt(self["material-ui"].ListSubheader,[],["MyTasks"])]],(children$1=List.ofSeq(Seq.delay(function()
   {
    return Seq.map(function(task)
    {
     var children$2;
     children$2=[ReactModule.elt(self["material-ui"].Checkbox,[["checked",task.State]],[]),ReactModule.elt(self["material-ui"].ListItemText,[],[task.Name])];
     return ReactModule.elt(self["material-ui"].ListItem,[["button",true],["onClick",function()
     {
      $this.ToggleTask(task);
     }]],children$2);
    },$this.state.Tasks);
   })),ReactModule.elt(self["material-ui"].List,props$1,children$1))),(props$2=[["fullWidth",true],["margin","normal"],["autoFocus",true],["value",this.state.Input],["placeholder","What needs to be done?"],["onChange",function(a)
   {
    $this.SetInput(a);
   }]],ReactModule.elt(self["material-ui"].TextField,props$2,[])),ReactModule.elt(self["material-ui"].Button,[["variant","contained"],["fullWidth",true],["color","primary"],["onClick",function()
   {
    $this.AddTask();
   }]],["Add"])];
   return ReactModule.elt(self["material-ui"].Paper,props,children);
  },
  ClearCompleted:function()
  {
   this.setState(State.New(this.state.Input,List.filter(function(task)
   {
    return!task.State;
   },this.state.Tasks)));
  },
  ToggleTask:function(task)
  {
   this.setState(State.New(this.state.Input,List.map(function(x)
   {
    return x.Name===task.Name?Task.New(task.Name,!task.State):x;
   },this.state.Tasks)));
  },
  SetInput:function(ev)
  {
   var i;
   this.setState((i=this.state,State.New(ev.target.value,i.Tasks)));
  },
  AddTask:function()
  {
   var $this;
   $this=this;
   this.state.Input.length>0&&!List.exists(function(task)
   {
    return task.Name===$this.state.Input;
   },this.state.Tasks)?$this.setState((this.state,State.New("",new T({
    $:1,
    $0:Task.New(this.state.Input,false),
    $1:this.state.Tasks
   })))):void 0;
  }
 },Component,Main);
 Main.New=Runtime.Ctor(function(props)
 {
  Component.call(this,props);
  this[0]=this;
  this.init=1;
  WebSharper.checkThis(this[0]).state=State.get_Default();
 },Main);
 ReactModule.elt=function(name,props,children)
 {
  return React.createElement(name,Pervasives.NewFromSeq(props),ReactModule.inlineArrayOfSeq(children));
 };
 ReactModule.inlineArrayOfSeq=function(s)
 {
  return s instanceof Global.Array?s:Arrays.ofSeq(s);
 };
 Pervasives.NewFromSeq=function(fields)
 {
  var r,e,f;
  r={};
  e=Enumerator.Get(fields);
  try
  {
   while(e.MoveNext())
    {
     f=e.Current();
     r[f[0]]=f[1];
    }
  }
  finally
  {
   if(typeof e=="object"&&"Dispose"in e)
    e.Dispose();
  }
  return r;
 };
 Arrays.ofSeq=function(xs)
 {
  var q,o;
  if(xs instanceof Global.Array)
   return xs.slice();
  else
   if(xs instanceof T)
    return Arrays.ofList(xs);
   else
    {
     q=[];
     o=Enumerator.Get(xs);
     try
     {
      while(o.MoveNext())
       q.push(o.Current());
      return q;
     }
     finally
     {
      if(typeof o=="object"&&"Dispose"in o)
       o.Dispose();
     }
    }
 };
 Arrays.ofList=function(xs)
 {
  var l,q;
  q=[];
  l=xs;
  while(!(l.$==0))
   {
    q.push(List.head(l));
    l=List.tail(l);
   }
  return q;
 };
 Unchecked.Equals=function(a,b)
 {
  var m,eqR,k,k$1;
  if(a===b)
   return true;
  else
   {
    m=typeof a;
    if(m=="object")
    {
     if(a===null||a===void 0||b===null||b===void 0)
      return false;
     else
      if("Equals"in a)
       return a.Equals(b);
      else
       if(a instanceof Global.Array&&b instanceof Global.Array)
        return Unchecked.arrayEquals(a,b);
       else
        if(a instanceof Global.Date&&b instanceof Global.Date)
         return Unchecked.dateEquals(a,b);
        else
         {
          eqR=[true];
          for(var k$2 in a)if(function(k$3)
          {
           eqR[0]=!a.hasOwnProperty(k$3)||b.hasOwnProperty(k$3)&&Unchecked.Equals(a[k$3],b[k$3]);
           return!eqR[0];
          }(k$2))
           break;
          if(eqR[0])
           {
            for(var k$3 in b)if(function(k$4)
            {
             eqR[0]=!b.hasOwnProperty(k$4)||a.hasOwnProperty(k$4);
             return!eqR[0];
            }(k$3))
             break;
           }
          return eqR[0];
         }
    }
    else
     return m=="function"&&("$Func"in a?a.$Func===b.$Func&&a.$Target===b.$Target:"$Invokes"in a&&"$Invokes"in b&&Unchecked.arrayEquals(a.$Invokes,b.$Invokes));
   }
 };
 Unchecked.arrayEquals=function(a,b)
 {
  var eq,i;
  if(Arrays.length(a)===Arrays.length(b))
   {
    eq=true;
    i=0;
    while(eq&&i<Arrays.length(a))
     {
      !Unchecked.Equals(Arrays.get(a,i),Arrays.get(b,i))?eq=false:void 0;
      i=i+1;
     }
    return eq;
   }
  else
   return false;
 };
 Unchecked.dateEquals=function(a,b)
 {
  return a.getTime()===b.getTime();
 };
 Ref.New=function(contents)
 {
  return[contents];
 };
 State.get_Default=function()
 {
  return State.New("",List.ofArray([Task.New("buy milk",false)]));
 };
 State.New=function(Input,Tasks)
 {
  return{
   Input:Input,
   Tasks:Tasks
  };
 };
 WebSharper.checkThis=function(_this)
 {
  return Unchecked.Equals(_this,null)?Operators.InvalidOp("The initialization of an object or value resulted in an object or value being accessed recursively before it was fully initialized."):_this;
 };
 Arrays.get=function(arr,n)
 {
  Arrays.checkBounds(arr,n);
  return arr[n];
 };
 Arrays.length=function(arr)
 {
  return arr.dims===2?arr.length*arr.length:arr.length;
 };
 Arrays.checkBounds=function(arr,n)
 {
  if(n<0||n>=arr.length)
   Operators.FailWith("Index was outside the bounds of the array.");
 };
 SC$1.$cctor=function()
 {
  var r,r$1;
  SC$1.$cctor=Global.ignore;
  SC$1.MyTheme=(r={},r.palette=(r$1={},r$1.primary=self["material-ui"].colors.green,r$1.type="dark",r$1),r);
 };
 T=List.T=Runtime.Class({
  GetEnumerator:function()
  {
   return new T$1.New(this,null,function(e)
   {
    var m;
    m=e.s;
    return m.$==0?false:(e.c=m.$0,e.s=m.$1,true);
   },void 0);
  }
 },null,T);
 T.Empty=new T({
  $:0
 });
 Enumerator.Get=function(x)
 {
  return x instanceof Global.Array?Enumerator.ArrayEnumerator(x):Unchecked.Equals(typeof x,"string")?Enumerator.StringEnumerator(x):x.GetEnumerator();
 };
 Enumerator.ArrayEnumerator=function(s)
 {
  return new T$1.New(0,null,function(e)
  {
   var i;
   i=e.s;
   return i<Arrays.length(s)&&(e.c=Arrays.get(s,i),e.s=i+1,true);
  },void 0);
 };
 Enumerator.StringEnumerator=function(s)
 {
  return new T$1.New(0,null,function(e)
  {
   var i;
   i=e.s;
   return i<s.length&&(e.c=s[i],e.s=i+1,true);
  },void 0);
 };
 List.ofArray=function(arr)
 {
  var r,i,$1;
  r=T.Empty;
  for(i=Arrays.length(arr)-1,$1=0;i>=$1;i--)r=new T({
   $:1,
   $0:Arrays.get(arr,i),
   $1:r
  });
  return r;
 };
 List.head=function(l)
 {
  return l.$==1?l.$0:List.listEmpty();
 };
 List.tail=function(l)
 {
  return l.$==1?l.$1:List.listEmpty();
 };
 List.listEmpty=function()
 {
  return Operators.FailWith("The input list was empty.");
 };
 List.filter=function(p,l)
 {
  return List.ofSeq(Seq.filter(p,l));
 };
 List.ofSeq=function(s)
 {
  var e,$1,go,r,res,t;
  if(s instanceof T)
   return s;
  else
   if(s instanceof Global.Array)
    return List.ofArray(s);
   else
    {
     e=Enumerator.Get(s);
     try
     {
      go=e.MoveNext();
      if(!go)
       $1=T.Empty;
      else
       {
        res=new T({
         $:1
        });
        r=res;
        while(go)
         {
          r.$0=e.Current();
          e.MoveNext()?r=(t=new T({
           $:1
          }),r.$1=t,t):go=false;
         }
        r.$1=T.Empty;
        $1=res;
       }
      return $1;
     }
     finally
     {
      if(typeof e=="object"&&"Dispose"in e)
       e.Dispose();
     }
    }
 };
 List.map=function(f,x)
 {
  var r,l,go,res,t;
  if(x.$==0)
   return x;
  else
   {
    res=new T({
     $:1
    });
    r=res;
    l=x;
    go=true;
    while(go)
     {
      r.$0=f(l.$0);
      l=l.$1;
      l.$==0?go=false:r=(t=new T({
       $:1
      }),r.$1=t,t);
     }
    r.$1=T.Empty;
    return res;
   }
 };
 List.exists=function(p,x)
 {
  var e,l;
  e=false;
  l=x;
  while(!e&&l.$==1)
   {
    e=p(l.$0);
    l=l.$1;
   }
  return e;
 };
 Task.New=function(Name,State$1)
 {
  return{
   Name:Name,
   State:State$1
  };
 };
 Obj=WebSharper.Obj=Runtime.Class({
  Equals:function(obj)
  {
   return this===obj;
  }
 },null,Obj);
 Obj.New=Runtime.Ctor(function()
 {
 },Obj);
 InvalidOperationException=WebSharper.InvalidOperationException=Runtime.Class({},Error,InvalidOperationException);
 InvalidOperationException.New=Runtime.Ctor(function(message)
 {
  InvalidOperationException.New$2.call(this,message,null);
 },InvalidOperationException);
 InvalidOperationException.New$2=Runtime.Ctor(function(message,innerExn)
 {
  this.message=message;
  this.inner=innerExn;
  Object.setPrototypeOf(this,InvalidOperationException.prototype);
 },InvalidOperationException);
 T$1=Enumerator.T=Runtime.Class({
  MoveNext:function()
  {
   return this.n(this);
  },
  Current:function()
  {
   return this.c;
  },
  Dispose:function()
  {
   if(this.d)
    this.d(this);
  }
 },Obj,T$1);
 T$1.New=Runtime.Ctor(function(s,c,n,d)
 {
  Obj.New.call(this);
  this.s=s;
  this.c=c;
  this.n=n;
  this.d=d;
 },T$1);
 Seq.delay=function(f)
 {
  return{
   GetEnumerator:function()
   {
    return Enumerator.Get(f());
   }
  };
 };
 Seq.map=function(f,s)
 {
  return{
   GetEnumerator:function()
   {
    var en;
    en=Enumerator.Get(s);
    return new T$1.New(null,null,function(e)
    {
     return en.MoveNext()&&(e.c=f(en.Current()),true);
    },function()
    {
     en.Dispose();
    });
   }
  };
 };
 Seq.filter=function(f,s)
 {
  return{
   GetEnumerator:function()
   {
    var o;
    o=Enumerator.Get(s);
    return new T$1.New(null,null,function(e)
    {
     var loop,c,res;
     loop=o.MoveNext();
     c=o.Current();
     res=false;
     while(loop)
      if(f(c))
       {
        e.c=c;
        res=true;
        loop=false;
       }
      else
       if(o.MoveNext())
        c=o.Current();
       else
        loop=false;
     return res;
    },function()
    {
     o.Dispose();
    });
   }
  };
 };
 Runtime.OnLoad(function()
 {
  Client.Main$1();
 });
}());


if (typeof IntelliFactory !=='undefined') {
  IntelliFactory.Runtime.ScriptBasePath = '/Content/';
  IntelliFactory.Runtime.Start();
}
