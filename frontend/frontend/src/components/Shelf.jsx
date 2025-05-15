import { useEffect } from 'react';
import { useGLTF } from '@react-three/drei';

export default function Shelf() {
    const { scene } = useGLTF('/models/shelf.gltf');

    return <primitive object={scene} scale={5} position={[0, 2.5, -9.5]} />;
}